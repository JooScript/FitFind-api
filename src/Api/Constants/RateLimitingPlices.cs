namespace ECommerce.Api.Constants;

/// <summary>
/// Contains constants for rate limiting policy names used throughout the application.
/// These policies define different rate limiting strategies for API endpoints.
/// </summary>
public static class RateLimitingPolicies
{
    /// <summary>
    /// Fixed window rate limiting policy.
    /// This policy allows a fixed number of requests per specified time window.
    /// </summary>
    /// <example>
    /// Configuration might allow 100 requests per minute using this policy.
    /// </example>
    public const string FixedWindow = "fixed";

    /// <summary>
    /// Sliding window rate limiting policy.
    /// This policy allows a fixed number of requests per time window, but the window
    /// slides continuously rather than resetting at fixed intervals. This provides
    /// smoother rate limiting compared to fixed window.
    /// </summary>
    /// <example>
    /// Configuration might allow 100 requests per minute with a sliding window,
    /// where requests are counted in overlapping time segments.
    /// </example>
    public const string SlidingWindow = "sliding";

    /// <summary>
    /// Token bucket rate limiting policy.
    /// This policy allows bursts of requests up to a maximum capacity while maintaining
    /// a steady average rate over time.
    /// </summary>
    public const string TokenBucket = "token";

    /// <summary>
    /// Concurrency rate limiting policy.
    /// This policy limits the number of simultaneous requests rather than requests per time period.
    /// </summary>
    public const string Concurrency = "concurrency";
}
