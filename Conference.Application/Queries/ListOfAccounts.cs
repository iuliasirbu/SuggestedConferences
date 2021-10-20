using Abstractions;
using FluentValidation;
using MediatR;
using ConferenceSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSystem.Application.Queries
{
    public class ListOfAccounts
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator(RatingDbContext _dbContext)
            {
                //RuleFor(q => q).Must(query =>
                //{
                //    var person = query.PersonId.HasValue ?
                //    _dbContext.Persons.FirstOrDefault(x => x.Id == query.PersonId) :
                //    _dbContext.Persons.FirstOrDefault(x => x.Cnp == query.Cnp);

                //    return person != null;
                //}).WithMessage("Customer not found");
            }
        }
       

        public class Query : IRequest<List<Model>>
        {
            public int? PersonId { get; set; }
            public string Cnp { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly RatingDbContext _dbContext;

            public QueryHandler(RatingDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                // TODO: implement logic
                return null;
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public decimal Balance { get; set; }
            public string Currency { get; set; }
            public string Iban { get; set; }
            public string Status { get; set; }
            public decimal? Limit { get; set; }
            public string Type { get; set; }
        }
    }
}
