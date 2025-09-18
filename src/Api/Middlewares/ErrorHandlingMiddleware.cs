using ECommerce.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace ECommerce.Api.Middlewares;

/// <summary>
/// Middleware for handling exceptions globally within the application.
/// Converts exceptions into standardized <see cref="ProblemDetails"/> responses
/// according to RFC 7807.
/// </summary>
/// <param name="logger">The logger used for writing exception details.</param>
public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    /// <summary>
    /// Invokes the middleware to process the current HTTP request and handle any unhandled exceptions.
    /// </summary>
    /// <param name="context">The current <see cref="HttpContext"/>.</param>
    /// <param name="next">The next <see cref="RequestDelegate"/> in the pipeline.</param>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            logger.LogWarning(ex, "Entity not found: {EntityName} with Id {EntityId}", ex.EntityName, ex.EntityId);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Entity not found",
                Detail = ex.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Instance = context.TraceIdentifier
            };

            await WriteProblemDetailsAsync(context, problemDetails, HttpStatusCode.NotFound);
        }
        catch (UnauthorizedAccessException ex)
        {
            logger.LogWarning(ex, "Unauthorized access");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized",
                Detail = "You do not have permission to perform this action.",
                Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                Instance = context.TraceIdentifier
            };

            await WriteProblemDetailsAsync(context, problemDetails, HttpStatusCode.Unauthorized);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred: {Message}", ex.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An unexpected error occurred.",
                Detail = "An internal server error has occurred. Please try again later.",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Instance = context.TraceIdentifier
            };

            await WriteProblemDetailsAsync(context, problemDetails, HttpStatusCode.InternalServerError);
        }
    }

    /// <summary>
    /// Writes a <see cref="ProblemDetails"/> object as a JSON response to the client.
    /// </summary>
    /// <param name="context">The current <see cref="HttpContext"/>.</param>
    /// <param name="problemDetails">The <see cref="ProblemDetails"/> to return.</param>
    /// <param name="code">The HTTP status code for the response.</param>
    private static async Task WriteProblemDetailsAsync(HttpContext context, ProblemDetails problemDetails, HttpStatusCode code)
    {
        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    }

}
