using Flights.Application.Contracts;
using Flights.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Flights.WebApi.Controllers
{
    [ApiController]
    [Route("api/Flights")]
    public class FlightManagerController : ControllerBase
    {
        private readonly IFlightRouteService _flightManagerService;

        public FlightManagerController(IFlightRouteService flightManagerService)
        {
            _flightManagerService = flightManagerService;
        }

        [AllowAnonymous]
        [HttpPost("CalculateRoute")]
        public async Task<IActionResult> CalculateRoute([FromBody] FlightRequestModel flightRequestModel)
        {
            var result = await _flightManagerService.CalculateRoute(flightRequestModel.Origin, flightRequestModel.Destination);
            var jsonString = JsonSerializer.Serialize(result);
            return Ok(jsonString);
        }
    }
}
