using ECommerce.Api.Constants;
using ECommerce.Api.Models;
using ECommerce.Bl.Application.Product.Commands;
using ECommerce.Bl.Application.Product.Queries;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Da.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json;

namespace ECommerce.Api.Controllers.Business;

/// <summary>
/// API controller for managing product operations.
/// </summary>
[Route("api/v1/Product")]
[ApiController]
//[Authorize]
public class ProductController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the product to retrieve.</param>
    /// <returns>
    /// Returns the product if found, otherwise returns NotFound.
    /// </returns>
    /// <response code="200">Returns the requested product</response>
    /// <response code="400">If the request is invalid</response>
    /// <response code="404">If the product is not found</response>
    /// <response code="500">If there was a server error</response>
    [HttpGet("ById/{id:Guid}", Name = "GetProductById")]
    [EnableRateLimiting(RateLimitingPolicies.FixedWindow)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<ProductDto>>> GetById(Guid id)
    {
        try
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
            {
                return NotFound(ApiResponse<ProductDto>.FailResponse($"Product with ID {id} not found."));
            }

            return base.Ok(ApiResponse<ProductDto>.SuccessResponse(product));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<ProductDto>.FailResponse("An error occurred while fetching the product",
                new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Adds a new product to the system.
    /// </summary>
    /// <param name="newProduct">The product data to add.</param>
    /// <returns>
    /// Returns the created product with its new ID and a 201 Created response.
    /// </returns>
    /// <response code="201">Returns the newly created product</response>
    /// <response code="400">If the product data is invalid</response>
    /// <response code="500">If there was a server error</response>
    [HttpPost(Name = "AddProduct")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<ProductDto>>> Add(ProductDto newProduct)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<ProductDto>.FailResponse("Invalid product data", errors));
            }

            var productId = await mediator.Send(new AddProductCommand(newProduct));



            if (productId == Guid.Empty)
            {
                return BadRequest(ApiResponse<ProductDto>.FailResponse("Failed to add product"));
            }

            newProduct.Id = productId;

            return CreatedAtRoute(
                "GetProductById",
                new { id = productId },
                ApiResponse<ProductDto>.SuccessResponse(newProduct, "Product created successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<ProductDto>.FailResponse("An error occurred while adding the product",
                new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    [HttpPut("{id:Guid}", Name = "UpdateProduct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<ProductDto>>> Update(Guid id, ProductDto updatedProduct)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<ProductDto>.FailResponse("Invalid product data", errors));
            }

            updatedProduct.Id = id;
            var updated = await mediator.Send(new UpdateProductCommand(id, updatedProduct));

            if (!updated)
            {
                return NotFound(ApiResponse<ProductDto>.FailResponse($"Product with ID {id} not found or update failed"));
            }

            return Ok(ApiResponse<ProductDto>.SuccessResponse(updatedProduct, "Product updated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<ProductDto>.FailResponse("An error occurred while updating the product",
                new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Gets a paginated list of all products.
    /// </summary>
    [HttpGet("All", Name = "GetAllProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<PagedResult<ProductDto>>>> GetAll(int pageNumber = 1, int pageSize = 50)
    {
        try
        {
            if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
            {
                return BadRequest(ApiResponse<PagedResult<ProductDto>>.FailResponse(
                    "Invalid pagination parameters. Page number must be ≥ 1 and page size between 1-100."));
            }

            var productsList = await mediator.Send(new GetAllProductsQuery(pageNumber, pageSize));

            if (productsList.TotalCount == 0)
            {
                return NotFound(ApiResponse<PagedResult<ProductDto>>.FailResponse("No products found"));
            }

            // Add pagination metadata to response headers
            Response.Headers.Append("X-Pagination",
                JsonSerializer.Serialize(new
                {
                    productsList.TotalCount,
                    productsList.PageSize,
                    productsList.CurrentPage,
                    productsList.TotalPages,
                    productsList.HasNext,
                    productsList.HasPrevious
                }));

            return Ok(ApiResponse<PagedResult<ProductDto>>.SuccessResponse(
                productsList,
                $"Found {productsList.TotalCount} products"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<PagedResult<ProductDto>>.FailResponse(
                    "An error occurred while retrieving products",
                    new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Checks if a product exists.
    /// </summary>
    [HttpGet("IsExists/{id:Guid}", Name = "IsProductExists")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<bool>>> IsExists(Guid id)
    {
        try
        {
            bool exists = await mediator.Send(new IsProductExistsQuery(id));

            return exists
                ? Ok(ApiResponse<bool>.SuccessResponse(true, "Product exists"))
                : NotFound(ApiResponse<bool>.FailResponse("Product not found"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.FailResponse(
                    "An error occurred while checking product existence",
                    new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Gets the total count of products.
    /// </summary>
    [HttpGet("Count", Name = "GetProductsCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<int>>> GetCount()
    {
        try
        {
            var count = await mediator.Send(new GetProductsCountQuery());
            return Ok(ApiResponse<int>.SuccessResponse(count, $"Found {count} products"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<int>.FailResponse(
                    "An error occurred while counting products",
                    new List<string> { ex.Message }));
        }
    }

    /// <summary>
    /// Deletes a product.
    /// </summary>
    [HttpDelete("{id:Guid}", Name = "DeleteProduct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            bool isDeleted = await mediator.Send(new DeleteProductCommand(id));

            if (isDeleted)
            {
                return Ok(ApiResponse<bool>.SuccessResponse(
                    true,
                    $"Product with ID {id} has been deleted"));
            }
            else
            {
                return NotFound(ApiResponse<bool>.FailResponse(
                    $"Product with ID {id} not found. No rows deleted"));
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.FailResponse(
                    "An error occurred while deleting product",
                    new List<string> { ex.Message }));
        }
    }

}