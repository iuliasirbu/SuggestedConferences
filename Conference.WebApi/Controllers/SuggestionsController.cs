using ConferenceSystem.Application.Queries;
using ConferenceSystem.Application.Queries;
using ConferenceSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static ConferenceSystem.Application.Queries.ListOfConferences;

namespace ConferenceSystem.WebApi.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("List")]
        public async Task<List<Model>> GetConferences(CancellationToken cancellationToken)
        {
            var query = new ListOfConferences.Query();
            var result = await _mediator.Send(query);
            return result;
        }

    }
}
