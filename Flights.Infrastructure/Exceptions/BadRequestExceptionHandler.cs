using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Infrastructure.Exceptions
{
    public class BadRequestExceptionHandler : IExceptionHandler
    {
        public IActionResult Handle(Exception exception)
        {
            if (exception is ArgumentException argumentException)
            {
                var errorDetails = $"A bad request error occurred: {argumentException.Message}";
                var errorResponse = new ObjectResult(errorDetails)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                };

                return errorResponse;
            }

            throw new ArgumentException("The exception type is not supported by this handler.", nameof(exception));
        }
    }
}
