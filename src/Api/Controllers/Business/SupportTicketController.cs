using ECommerce.Api.Models;
using ECommerce.Bl.Application.SupportTicket.Commands;
using ECommerce.Bl.Application.SupportTicket.Queries;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Da.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ECommerce.Api.Controllers.Business;

/// <summary>
/// API controller for managing Support Ticket operations.
/// </summary>
[Route("api/v1/SupportTicket")]
[ApiController]
//[Authorize]
public class SupportTicketController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves a Support Ticket by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the Support Ticket to retrieve.</param>
    /// <returns>
    /// Returns the Support Ticket if found, otherwise returns NotFound.
    /// </returns>
    /// <response code="200">Returns the requested Support Ticket</response>
    /// <response code="400">If the request is invalid</response>
    /// <response code="404">If the Support Ticket is not found</response>
    /// <response code="500">If there was a server error</response>
    [HttpGet("ById/{id:Guid}", Name = "GetSupportTicketById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<SupportTicketDto>>> GetById(Guid id)
    {
        try
        {
            var SupportTicket = await mediator.Send(new GetSupportTicketByIdQuery(id));

            if (SupportTicket == null)
            {
                return NotFound(ApiResponse<SupportTicketDto>.FailResponse($"SupportTicket with ID {id} not found."));
            }

            return base.Ok(ApiResponse<SupportTicketDto>.SuccessResponse(SupportTicket));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<SupportTicketDto>.FailResponse("An error occurred while fetching the SupportTicket",
                new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Adds a new Support Ticket to the system.
    /// </summary>
    /// <param name="newSupportTicket">The Support Ticket data to add.</param>
    /// <returns>
    /// Returns the created Support Ticket with its new ID and a 201 Created response.
    /// </returns>
    /// <response code="201">Returns the newly created Support Ticket</response>
    /// <response code="400">If the Support Ticket data is invalid</response>
    /// <response code="500">If there was a server error</response>
    [HttpPost(Name = "AddSupportTicket")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<SupportTicketDto>>> Add(SupportTicketDto newSupportTicket)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<SupportTicketDto>.FailResponse("Invalid SupportTicket data", errors));
            }

            var SupportTicketId = await mediator.Send(new AddSupportTicketCommand(newSupportTicket));



            if (SupportTicketId == Guid.Empty)
            {
                return BadRequest(ApiResponse<SupportTicketDto>.FailResponse("Failed to add SupportTicket"));
            }

            newSupportTicket.Id = SupportTicketId;

            return CreatedAtRoute(
                "GetSupportTicketById",
                new { id = SupportTicketId },
                ApiResponse<SupportTicketDto>.SuccessResponse(newSupportTicket, "SupportTicket created successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<SupportTicketDto>.FailResponse("An error occurred while adding the SupportTicket",
                new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Updates an existing Support Ticket.
    /// </summary>
    [HttpPut("{id:Guid}", Name = "UpdateSupportTicket")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<SupportTicketDto>>> Update(Guid id, SupportTicketDto updatedSupportTicket)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<SupportTicketDto>.FailResponse("Invalid SupportTicket data", errors));
            }

            updatedSupportTicket.Id = id;
            var updated = await mediator.Send(new UpdateSupportTicketCommand(id, updatedSupportTicket));

            if (!updated)
            {
                return NotFound(ApiResponse<SupportTicketDto>.FailResponse($"SupportTicket with ID {id} not found or update failed"));
            }

            return Ok(ApiResponse<SupportTicketDto>.SuccessResponse(updatedSupportTicket, "Support Ticket updated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<SupportTicketDto>.FailResponse("An error occurred while updating the SupportTicket",
                new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Gets a paginated list of all Support Tickets.
    /// </summary>
    [HttpGet("All", Name = "GetAllSupportTickets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<PagedResult<SupportTicketDto>>>> GetAll(int pageNumber = 1, int pageSize = 50)
    {
        try
        {
            if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
            {
                return BadRequest(ApiResponse<PagedResult<SupportTicketDto>>.FailResponse(
                    "Invalid pagination parameters. Page number must be ≥ 1 and page size between 1-100."));
            }

            var SupportTicketsList = await mediator.Send(new GetAllSupportTicketsQuery(pageNumber, pageSize));

            if (SupportTicketsList.TotalCount == 0)
            {
                return NotFound(ApiResponse<PagedResult<SupportTicketDto>>.FailResponse("No SupportTickets found"));
            }

            // Add pagination metadata to response headers
            Response.Headers.Append("X-Pagination",
                JsonSerializer.Serialize(new
                {
                    SupportTicketsList.TotalCount,
                    SupportTicketsList.PageSize,
                    SupportTicketsList.CurrentPage,
                    SupportTicketsList.TotalPages,
                    SupportTicketsList.HasNext,
                    SupportTicketsList.HasPrevious
                }));

            return Ok(ApiResponse<PagedResult<SupportTicketDto>>.SuccessResponse(
                SupportTicketsList,
                $"Found {SupportTicketsList.TotalCount} SupportTickets"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<PagedResult<SupportTicketDto>>.FailResponse(
                    "An error occurred while retrieving SupportTickets",
                    new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Checks if a Support Ticket exists.
    /// </summary>
    [HttpGet("IsExists/{id:Guid}", Name = "IsSupportTicketExists")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<bool>>> IsExists(Guid id)
    {
        try
        {
            bool exists = await mediator.Send(new IsSupportTicketExistsQuery(id));

            return exists
                ? Ok(ApiResponse<bool>.SuccessResponse(true, "SupportTicket exists"))
                : NotFound(ApiResponse<bool>.FailResponse("SupportTicket not found"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.FailResponse(
                    "An error occurred while checking SupportTicket existence",
                    new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Gets the total count of Support Tickets.
    /// </summary>
    [HttpGet("Count", Name = "GetSupportTicketsCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<int>>> GetCount()
    {
        try
        {
            var count = await mediator.Send(new GetSupportTicketsCountQuery());
            return Ok(ApiResponse<int>.SuccessResponse(count, $"Found {count} SupportTickets"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<int>.FailResponse(
                    "An error occurred while counting SupportTickets",
                    new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Deletes a Support Ticket.
    /// </summary>
    [HttpDelete("{id:Guid}", Name = "DeleteSupportTicket")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            bool isDeleted = await mediator.Send(new DeleteSupportTicketCommand(id));

            if (isDeleted)
            {
                return Ok(ApiResponse<bool>.SuccessResponse(
                    true,
                    $"SupportTicket with ID {id} has been deleted"));
            }
            else
            {
                return NotFound(ApiResponse<bool>.FailResponse(
                    $"SupportTicket with ID {id} not found. No rows deleted"));
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.FailResponse(
                    "An error occurred while deleting SupportTicket",
                    new List<string> { ex.Message }));
        }
    }

}