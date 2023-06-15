using Microsoft.AspNetCore.Mvc;

namespace Flights.Infrastructure.Exceptions
{
    public interface IExceptionHandler
    {
        IActionResult Handle(Exception exception);
    }
}
