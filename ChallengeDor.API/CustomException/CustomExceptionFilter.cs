using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChallengeDor.API.CustomException
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException) // Detecta el tipo de excepción que deseas manejar
            {
                context.Result = new BadRequestObjectResult("A required value is missing.");
                context.ExceptionHandled = true;
            }
        }
    }

}
