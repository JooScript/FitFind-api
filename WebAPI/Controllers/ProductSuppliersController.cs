using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/ProductSuppliers")]
    [ApiController]
    public class ProductSuppliersController : ControllerBase
    {        IProductSupplier oProductSupplier;
        private readonly IMapper _mapper;
        public ProductSuppliersController(IProductSupplier productSupplier, IMapper mapper)
        {
            oProductSupplier = productSupplier;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetProductSupplierById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductSupplierDTO>> GetProductSupplierById(long Id)
        {
            TbProductSupplier productSupplier = await oProductSupplier.GetById(Id);

            if (productSupplier == null)
            {
                return NotFound($"ProductSupplier with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ProductSupplierDTO>(productSupplier));
        }        [HttpPost(Name = "AddProductSupplier")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductSupplierDTO>> AddProductSupplier(ProductSupplierDTO newProductSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productSupplier data.");
            }

            long productSupplierId = await oProductSupplier.Add(_mapper.Map<TbProductSupplier>(newProductSupplier));

            if (productSupplierId <= 0)
            {
                return BadRequest("Failed to add productSupplier.");
            }

            newProductSupplier.Id = productSupplierId;

            return CreatedAtRoute("GetProductSupplierById", new { id = productSupplierId }, newProductSupplier);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateProductSupplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductSupplierDTO>> UpdateProductSupplier(long Id, ProductSupplierDTO updatedProductSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productSupplier data.");
            }

            if (!await oProductSupplier.IsExists(Id))
            {
                return NotFound($"ProductSupplier with ID {Id} not found.");
            }

            updatedProductSupplier.Id = Id;

            if (!await oProductSupplier.Update(_mapper.Map<TbProductSupplier>(updatedProductSupplier)))
            {
                return BadRequest("Failed to update productSupplier.");
            }

            return Ok(updatedProductSupplier);
        }        [HttpGet("All", Name = "GetAllProductSuppliers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductSupplierDTO>>> GetAllProductSuppliers(int pageNumber = 1, int pageSize = 50)
        {
            var productSuppliersList = await oProductSupplier.GetAll(pageNumber, pageSize);
            if (productSuppliersList.Count == 0)
            {
                return NotFound("No ProductSuppliers Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ProductSupplierDTO>>(productSuppliersList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsProductSupplierExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsProductSupplierExists(long Id)
        {
            bool exists = await oProductSupplier.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "ProductSupplier Not Found!" });
            }
            return Ok(new { Message = "ProductSupplier Exists" });
        }

        [HttpGet("Count", Name = "GetProductSuppliersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetProductSuppliersCount()
        {
            return Ok(await oProductSupplier.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteProductSupplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductSupplier(long Id)
        {        
            if (await oProductSupplier.Delete(Id))
            {
                return Ok($"ProductSupplier with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"ProductSupplier with ID {Id} not found. No rows deleted!");
            }
        }

    }
}