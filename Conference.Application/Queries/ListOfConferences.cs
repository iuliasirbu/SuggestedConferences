using ConferenceSystem.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSystem.Application.Queries
{
    public class ListOfConferences
    {
        public class Query : IRequest<List<Model>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly AfterhillsContext _afterhillsContext;

            public QueryHandler(AfterhillsContext afterhillsContext)
            {
                _afterhillsContext = afterhillsContext; 
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {

                var db = _afterhillsContext.Conferences;

                var result = db.Select(x => new Model
                {
                    Id = x.Id,
                    OrganizerEmail = x.OrganizerEmail,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Name = x.Name,
                    ConferenceTypeId = x.ConferenceTypeId,
                    LocationId = x.LocationId,
                    CategoryId = x.CategoryId
                }).Take(3).ToList();

                return Task.FromResult(result);
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public int ConferenceTypeId { get; set; }
            public int LocationId { get; set; }
            public string OrganizerEmail { get; set; }
            public int CategoryId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Name { get; set; }
        }
            
    }
}
