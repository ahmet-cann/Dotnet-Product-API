using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; 
using System;
using System.Threading.Tasks;

namespace FIRSTAPI.Middleware
{
    public class GlobalExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger; 

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen hata oluştu.", ex.Message);
                
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                
                var errorResponse = new
                {
                    status = 500,
                    message = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
                    details = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? ex.Message : null
                };
                
                // SENİN ORİJİNAL KODUN: Artık hata vermeyecek!
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        } 
    }
}