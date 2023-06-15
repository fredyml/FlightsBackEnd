using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Flights.Infrastructure.Exceptions
{
    public class SqlExceptionHandler : IExceptionHandler
    {
        public IActionResult Handle(Exception exception)
        {
            if (exception is SqlException sqlException)
            {
                var errorMessage = $"A database error occurred: {sqlException.Message}";
                var errorResponse = new ObjectResult(errorMessage)
                {
                    StatusCode = StatusCodes.Status503ServiceUnavailable,
                };

                return errorResponse;
            }

            throw new ArgumentException("The exception type is not supported by this handler.", nameof(exception));
        }
    }
}
