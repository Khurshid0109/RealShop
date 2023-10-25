using RealShop.Api.Helpers;
using RealShop.Services.Exceptions;

namespace RealShop.Api.MiddleWares
{
    public class ExceptionHandlerMiddleWare:Exception
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(CustomException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new Responce
                {
                    Code = ex.StatusCode,
                    Message = ex.Message,
                });

            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Responce
                {
                    Code = 500,
                    Message = ex.Message,
                });
            }
        }
    }
}
