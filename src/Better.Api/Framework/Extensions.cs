using Microsoft.AspNetCore.Builder;

namespace Better.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionHandlerCustom(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}