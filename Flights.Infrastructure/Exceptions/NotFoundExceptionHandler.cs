using Flights.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Infrastructure.Exceptions
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public IActionResult Handle(Exception exception)
        {
            if (exception is NotFoundException notFoundException)
            {
                var errorDetails = $"The requested resource was not found: {notFoundException.Message}";
                var errorResponse = new ObjectResult(errorDetails)
                {
                    StatusCode = StatusCodes.Status404NotFound,
                };

                return errorResponse;
            }

            throw new ArgumentException("The exception type is not supported by this handler.", nameof(exception));
        }
    }
}
