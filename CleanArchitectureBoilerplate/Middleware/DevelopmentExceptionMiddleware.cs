using CleanArchitectureBoilerplate.Models.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitectureBoilerplate.Middleware
{
    public class DevelopmentExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public DevelopmentExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var returnedErrorMessage = ex.Message;
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (ex is NotFoundException) code = HttpStatusCode.NotFound;
            else if (ex is UnauthorizedException) code = HttpStatusCode.Unauthorized;
            //TODO: Define custom base exception class then add behaviour here.
            //else if (ex is MyException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { error = returnedErrorMessage });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
