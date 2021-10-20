//using ConferenceSystem.Data;
//using ConferenceSystem.Models;
//using ConferenceSystem.PublishedLanguage.Commands;
//using ConferenceSystem.Data;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ConferenceSystem.Application.CommandHandlers
//{
//    public class CreateConference : IRequestHandler<CreateConferenceCommand>
//    {
//        private readonly IMediator _mediator;
//        private readonly AfterhillsContext _afterhillsContext;

//        public CreateConference(IMediator mediator, AfterhillsContext afterhillsContext)
//        {
//            _mediator = mediator;
//            _afterhillsContext = afterhillsContext;
//        }

//        public async Task<Unit> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
//        {
//            var conference = new Conference
//            {
//                Name = request.Name,
//                OrganizerEmail = request.OrganizerEmail,
//                StartDate = request.StartDate,
//                EndDate = request.EndDate,
//                ConferenceTypeId = request.ConferenceTypeId,
//                LocationId = request.LocationId,
//                CategoryId = request.CategoryId
//            };

//            _afterhillsContext.Conferences.Add(conference);
//            _afterhillsContext.SaveChanges();

//            CreateConferenceCommand createConference = new(request.Name, request.OrganizerEmail, request.StartDate, request.EndDate, request.ConferenceTypeId, request.LocationId, request.CategoryId);
//            await _mediator.Publish(createConference, cancellationToken);
//            return Unit.Value;


//        }
//    }
//}
