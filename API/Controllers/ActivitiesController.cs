using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivitiesController:ControllerBase
    {
        private readonly IMediator mediator;

        public ActivitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List(CancellationToken ct) {

            return await mediator.Send(new List.Query(),ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id) {
            return await mediator.Send(new Details.Query { Id=id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command) {

            return await mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command) {
            command.Id = id;

            return await mediator.Send(command);       
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id) {
            return await mediator.Send(new Delete.Command { Id = id });
        }
    }
}
