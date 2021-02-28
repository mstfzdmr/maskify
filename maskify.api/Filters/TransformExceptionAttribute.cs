using maskify.api.Exceptions;
using maskify.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace maskify.api.Filters
{
    public class TransformExceptionAttribute : ExceptionFilterAttribute
    {
        public Type ExceptionType { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public TransformExceptionAttribute(Type type, HttpStatusCode statusCode, string message = null, int code = 0)
        {
            ExceptionType = type;
            StatusCode = statusCode;
            Message = message;
            Code = code;

            if ((int)StatusCode < 400)
            {
                throw new Exception("You cannot transform exceptions to successful http status codes.");
            }
        }
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception == null)
            {
                context.ExceptionHandled = false;
                return;
            }

            if (!ExceptionType.IsInstanceOfType(context.Exception))
            {
                context.ExceptionHandled = false;
                return;
            }

            var errorResponse = new MaskifyResponse
            {
                Code = Code > 0 ? Code : (int)StatusCode,
                Message = Message,
                InternalMessage = context.Exception.Message
            };

            if (context.Exception is MessageExceptions)
                errorResponse.InternalMessage = context.Exception.Message;

            var objectResult = new ObjectResult(errorResponse) { StatusCode = (int)StatusCode };
            context.ExceptionHandled = true;
            context.Result = objectResult;
        }
    }
}
