using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;

namespace TicketBooking
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
            return app;
        }
    }


    public class GlobalExceptionMiddleware : IMiddleware
    {
        //private readonly RequestDelegate _next;
        //private readonly ILogger<GlobalExceptionMiddleware> _logger;

        //public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        //{
        //    _next = next;
        //    _logger = logger;
        //}

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    try
        //    {
        //        await _next(context);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception to a JSON file in the "log" folder
        //        var logFolder = "log";
        //        var logPath = Path.Combine(logFolder, "Log.json");

        //        var logEntry = new
        //        {
        //            Timestamp = DateTime.Now,
        //            Message = ex.Message,
        //            StackTrace = ex.StackTrace
        //        };

        //        var serializedLogEntry = JsonConvert.SerializeObject(logEntry);

        //        File.AppendAllText(logPath, serializedLogEntry + Environment.NewLine);

        //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        context.Response.ContentType = "application/json";

        //        // Create a response object with the error details
        //        var response = new
        //        {
        //            StatusCode = context.Response.StatusCode,
        //            Message = "An error occurred on the server."
        //        };

        //        // Convert the response object to JSON format
        //        var jsonResponse = JsonConvert.SerializeObject(response);

        //        // Write the JSON response to the HTTP response
        //        await context.Response.WriteAsync(jsonResponse);
        //    }
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Log the exception to a JSON file in the "log" folder
                var logFolder = "log";
                var logPath = Path.Combine(logFolder, "Log.json");

                var logEntry = new
                {
                    Timestamp = DateTime.Now,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };

                var serializedLogEntry = JsonConvert.SerializeObject(logEntry);

                File.AppendAllText(logPath, serializedLogEntry + Environment.NewLine);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Create a response object with the error details
                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An error occurred on the server."
                };

                // Convert the response object to JSON format
                var jsonResponse = JsonConvert.SerializeObject(response);

                // Write the JSON response to the HTTP response
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
