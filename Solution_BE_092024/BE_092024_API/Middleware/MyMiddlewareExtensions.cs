namespace BE_092024_API.Middleware
{
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder MiddlewareOfBE092024(this IApplicationBuilder builder) 
        { 
            return builder.UseMiddleware<MyCustomeMiddleware>(); 
        }
    }
}
