/*
 * Staat - Staat
 * Copyright (C) 2021 Matthew Kilgore (tankerkiller125)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or (at your
 * option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Staat.Data;
using Staat.Extensions;
using Staat.GraphQL.Mutations.Inputs.Incident;
using Staat.GraphQL.Mutations.Payloads.Incident;
using Staat.Helpers;
using Staat.Models;

namespace Staat.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    [Authorize]
    public class IncidentMutation
    {
        private IHttpContextAccessor _httpContextAccessor;
        public IncidentMutation(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [UseApplicationContext]
        public async Task<IncidentBasePayload> AddIncidentAsync(AddIncidentInput input,
            [ScopedService] ApplicationDbContext context, CancellationToken cancellationToken)
        {
            DateTime? endedAt = null;
            if (input.EndedAt.HasValue)
            {
                endedAt = input.EndedAt;
            }
            
            var incident = new Incident
            {
                Title = input.Title,
                Description = input.Description,
                DescriptionHtml = MarkdownHelper.ToHtml(input.Description),
                Service = await context.Service.FindAsync(input.ServiceId),
                StartedAt = input.StartedAt,
                EndedAt = endedAt,
                Author = context.User.First(x => x.Id == Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value))
            };
            await context.Incident.AddAsync(incident, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new IncidentBasePayload(incident);
        }
    }
}