/*
 * Copyright
 */

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Staat.Data;
using Staat.GraphQL.Mutations;
using Staat.Services;
using Staat.GraphQL.Queries;

namespace Staat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                options.UseMemoryCache(new MemoryCache(new MemoryCacheOptions()));
            });

            services.AddGraphQLServer()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ServiceGroupQuery>()
                .AddTypeExtension<ServiceQuery>()
                .AddTypeExtension<IncidentQuery>()
                .AddTypeExtension<SettingsQuery>()
                .AddTypeExtension<UserQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ServiceGroupMutation>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal?.Identity?.Name ?? "0");
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }

                        return Task.CompletedTask;
                    }
                };
                var key = Encoding.ASCII.GetBytes(Configuration.GetSection("App")["Secret"]);
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Staat", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Staat v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets();
            
            app.UseEndpoints(endpoints => { 
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}