using System.Net;
using System.Web.Http.Filters;
using Core.Exceptions;

namespace API.Filters;

// TODO: Figure out why this does not catch any exceptions
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

    public async override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext,
        CancellationToken cancellationToken)
    {
        OnException(actionExecutedContext);
    }
}