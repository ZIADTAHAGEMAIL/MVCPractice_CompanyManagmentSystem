
using Microsoft.AspNetCore.Http.HttpResults;

namespace MVCPractice.Middlewares
{
    public class Global_Exception_Handling_Middleware : IMiddleware
    {
        private readonly ILogger<Global_Exception_Handling_Middleware> _logger;

        public Global_Exception_Handling_Middleware(ILogger<Global_Exception_Handling_Middleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {

                await next.Invoke(context);
            }
            catch (KeyNotFoundException e)
            {
                _logger.LogWarning(e, "الموظف أو القسم غير موجود");

                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.Redirect("/Home/NotFound");
            }
            catch (Exception e)
            {

                //Console.WriteLine($"[CATCH CAPTURED]: {e.Message}");
                _logger.LogError(e, "حدث خطأ غير متوقع!");
                context.Response.StatusCode= StatusCodes.Status500InternalServerError;
                context.Response.Redirect("/Home/Error");
            }


        }
    }
}
