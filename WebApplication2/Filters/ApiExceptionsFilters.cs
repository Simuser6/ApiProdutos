using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication2.Filters
{
    public class ApiExceptionsFilters : IExceptionFilter
    {

        private readonly ILogger<ApiExceptionsFilters> logger;  

        public ApiExceptionsFilters(ILogger<ApiExceptionsFilters> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            this.logger.LogError(context.Exception, "Error 500");

            context.Result = new ObjectResult("Ocorreu um Erro")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
