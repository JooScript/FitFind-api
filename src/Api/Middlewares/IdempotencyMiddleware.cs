using Microsoft.Extensions.Caching.Memory;

namespace ECommerce.Api.Middlewares;

public class IdempotencyMiddleware(IMemoryCache cache) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
    {
        if (context.Request.Headers.TryGetValue("Idempotency-Key", out var key))
        {
            if (cache.TryGetValue(key, out var response))
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
                return;
            }

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            cache.Set(key.ToString(), text, TimeSpan.FromMinutes(5));

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        else
        {
            await _next(context);
        }
    }
}
