using MediatR;
using ConferenceSystem.Application.Services;
using ConferenceSystem.Data;
using ConferenceSystem.Models;
using ConferenceSystem.PublishedLanguage.Commands;
using ConferenceSystem.PublishedLanguage.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSystem.Application.WriteOperations
{
    public class CreateAccount : IRequestHandler<MakeNewAccount>
    {
        private readonly IMediator _mediator;
        private readonly AccountOptions _accountOptions;
        private readonly RatingDbContext _dbContext;
        private readonly NewIban _ibanService;

        public CreateAccount(IMediator mediator, AccountOptions accountOptions, RatingDbContext dbContext, NewIban ibanService)
        {
            _mediator = mediator;
            _accountOptions = accountOptions;
            _dbContext = dbContext;
            _ibanService = ibanService;
        }

        public async Task<Unit> Handle(MakeNewAccount request, CancellationToken cancellationToken)
        {
            // TODO: implement logic
            return Unit.Value;
        }        
    }
}
