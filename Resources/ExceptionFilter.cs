using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConciliatorServices.Resources
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception.InnerException!=null ? 
                context.Exception.InnerException.Message : context.Exception.Message;

            context.Result = BadRequestObjectResult(exception);
        }

        public IActionResult BadRequestObjectResult(string exception)
        {
            var result = new BadRequestObjectResult(exception);
            return result;
        } 

    }
 
}