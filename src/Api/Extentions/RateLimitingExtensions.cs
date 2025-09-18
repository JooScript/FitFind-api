using ECommerce.Api.Constants;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace ECommerce.Api.Extentions;

/// <summary>
/// Provides extension methods for configuring rate limiting policies in the application.
/// </summary>
public static class RateLimitingExtensions
{
    /// <summary>
    /// Adds and configures multiple rate limiting policies to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the rate limiter to.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    /// <remarks>
    /// Configures four different rate limiting strategies:
    /// <list type="bullet">
    /// <item><description><see cref="RateLimitingPolicies.FixedWindow"/>: Fixed window policy (5 requests per 5 seconds)</description></item>
    /// <item><description><see cref="RateLimitingPolicies.SlidingWindow"/>: Sliding window policy (4 requests per 10 seconds with 3 segments)</description></item>
    /// <item><description><see cref="RateLimitingPolicies.Concurrency"/>: Concurrency policy (5 simultaneous requests)</description></item>
    /// <item><description><see cref="RateLimitingPolicies.TokenBucket"/>: Token bucket policy (10 token limit, 5 tokens replenished every 10 seconds)</description></item>
    /// </list>
    /// All policies return HTTP 429 Too Many Requests when the limit is exceeded.
    /// </remarks>
    /// <example>
    /// Usage in Program.cs:
    /// <code>
    /// builder.Services.AddRateLimiters();
    /// </code>
    /// </example>
    public static IServiceCollection AddRateLimiters(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter(RateLimitingPolicies.FixedWindow, limiterOpt =>
            {
                limiterOpt.PermitLimit = 5;
                limiterOpt.Window = TimeSpan.FromSeconds(5);
                limiterOpt.QueueLimit = 10;
                limiterOpt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddSlidingWindowLimiter(RateLimitingPolicies.SlidingWindow, limiterOpt =>
            {
                limiterOpt.Window = TimeSpan.FromSeconds(10);
                limiterOpt.PermitLimit = 4;
                limiterOpt.QueueLimit = 2;
                limiterOpt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                limiterOpt.SegmentsPerWindow = 3;
            }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddConcurrencyLimiter(RateLimitingPolicies.Concurrency, limiterOpt =>
            {
                limiterOpt.PermitLimit = 5;
                limiterOpt.QueueLimit = 2;
                limiterOpt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddTokenBucketLimiter(RateLimitingPolicies.TokenBucket, limiterOpt =>
            {
                limiterOpt.TokenLimit = 10;
                limiterOpt.QueueLimit = 5;
                limiterOpt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                limiterOpt.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
                limiterOpt.TokensPerPeriod = 5;
                limiterOpt.AutoReplenishment = true;
            }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;

        });

        return services;
    }
}