using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Staat.Data;
using Staat.Extensions;
using Staat.Models;

namespace Staat.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class IncidentQuery
    {
        [UseApplicationContext]
        [UsePaging(MaxPageSize = 50)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Incident> GetIncident([ScopedService] ApplicationDbContext context) => context.Incident;
    }
}