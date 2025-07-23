using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {        IProduct oProduct;
        private readonly IMapper _mapper;
        public ProductsController(IProduct product, IMapper mapper)
        {
            oProduct = product;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProductById(long Id)
        {
            TbProduct product = await oProduct.GetById(Id);

            if (product == null)
            {
                return NotFound($"Product with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ProductDTO>(product));
        }        [HttpPost(Name = "AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDTO>> AddProduct(ProductDTO newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product data.");
            }

            long productId = await oProduct.Add(_mapper.Map<TbProduct>(newProduct));

            if (productId <= 0)
            {
                return BadRequest("Failed to add product.");
            }

            newProduct.Id = productId;

            return CreatedAtRoute("GetProductById", new { id = productId }, newProduct);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(long Id, ProductDTO updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product data.");
            }

            if (!await oProduct.IsExists(Id))
            {
                return NotFound($"Product with ID {Id} not found.");
            }

            updatedProduct.Id = Id;

            if (!await oProduct.Update(_mapper.Map<TbProduct>(updatedProduct)))
            {
                return BadRequest("Failed to update product.");
            }

            return Ok(updatedProduct);
        }        [HttpGet("All", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(int pageNumber = 1, int pageSize = 50)
        {
            var productsList = await oProduct.GetAll(pageNumber, pageSize);
            if (productsList.Count == 0)
            {
                return NotFound("No Products Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(productsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsProductExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsProductExists(long Id)
        {
            bool exists = await oProduct.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Product Not Found!" });
            }
            return Ok(new { Message = "Product Exists" });
        }

        [HttpGet("Count", Name = "GetProductsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetProductsCount()
        {
            return Ok(await oProduct.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct(long Id)
        {        
            if (await oProduct.Delete(Id))
            {
                return Ok($"Product with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Product with ID {Id} not found. No rows deleted!");
            }
        }

    }
}