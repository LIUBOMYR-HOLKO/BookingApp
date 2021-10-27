using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.WorkplaceBookingFeatures.Queries;
using Application.Features.WorkplaceBookingFeatures.Commands;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceBookingController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkplaceBookingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWorkplaceBookingQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetWorkplaceBookingByIdQuery { Id = id }));
        }
    }
}
