using System.Net;
using System.Web.Http.Filters;
using Core.Exceptions;

namespace API.Filters;

public class BudgetPalExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext actionExecutedContext)
    {
        if (actionExecutedContext.Exception is NotFoundException err)
        {
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(err.Message)
            };
        }
    }
}