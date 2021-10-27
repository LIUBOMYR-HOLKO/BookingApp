using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.WorkplaceBookingFeatures.Queries;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceBookingController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWorkplaceBookingQuery()));
        }
    }
}
