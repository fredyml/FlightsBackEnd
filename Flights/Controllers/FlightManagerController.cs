using Flights.Application.Contracts;
using Flights.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flights.WebApi.Controllers
{
    [ApiController]
    [Route("api/Flights")]
    public class FlightManagerController : ControllerBase
    {
        private readonly IFlightManagerService _flightManagerService;

        public FlightManagerController(IFlightManagerService flightManagerService) 
        { 
            _flightManagerService = flightManagerService;
        }

        [AllowAnonymous]
        [HttpPost("CalculateRoute")]
        public IActionResult CalculateRoute([FromBody] FlightRequestModel flightRequestModel)
        {
            var route = new FlightRequestModel
            {
                Origin = flightRequestModel.Origin,
                Destination = flightRequestModel.Destination
            };

            return Ok(route);
        }
    }
}
