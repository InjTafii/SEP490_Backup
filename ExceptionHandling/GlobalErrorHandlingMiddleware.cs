using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                var generalException = new CustomException(HttpStatusCode.InternalServerError, "An unexpected error occurred.", ex.Message, null);
                await HandleExceptionAsync(context, generalException);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, CustomException exception)
        {
            var response = new
            {
                code = (int)exception.Status,
                msg = exception.Message,
                status = exception.Error,
                data = exception.Data
            };

            var result = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.Status;

            return context.Response.WriteAsync(result);
        }

    }
}
