using Microsoft.AspNetCore.Http;

namespace BE_092024_API.Middleware
{
    public class MyCustomeMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //  await context.Response.WriteAsync("Middleware from Mr Quan!");
             context.Response.Headers.Add("HackerBy", "MRQuan");
             await _next(context);

        }
    }
}
