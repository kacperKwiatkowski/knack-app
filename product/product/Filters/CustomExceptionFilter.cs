using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using product.Exceptions;

namespace product.Filters;

public class CustomExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        string apiError = null;
        
        if (context.Exception is ItemNotFoundException)
        {
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
            apiError = context.Exception.Message;
        }
        
        context.Result = new JsonResult(apiError);

        base.OnException(context);
    }
}