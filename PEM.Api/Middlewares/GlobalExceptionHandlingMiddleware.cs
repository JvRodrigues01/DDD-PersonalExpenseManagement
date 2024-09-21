using PEM.Application.Models;
using System.Net;
using System.Text.Json;

namespace PEM.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        protected readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            //catch (NonAuthoritativeException ex)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            //    var response = new BaseResult<object>(false, ex.Message);
            //    HandleException(response, context);
            //}
            //catch (BadRequestException ex)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    var response = new BaseResult<object>(false, ex.Message);
            //    HandleException(response, context);
            //}
            //catch (NotFoundException ex)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            //    var response = new BaseResult<object>(false, ex.Message);
            //    HandleException(response, context);
            //}
            //catch (ConflictException ex)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            //    var response = new BaseResult<object>(false, ex.Message);
            //    HandleException(response, context);
            //}
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new BaseResult<object>(null, false, ex.Message);
                HandleException(response, context);
            }
        }

        private async void HandleException(BaseResult<object> response, HttpContext context)
        {
            _logger.LogError(response.Message);
            string json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
