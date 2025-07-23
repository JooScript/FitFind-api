using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/ProductCategoryMappings")]
    [ApiController]
    public class ProductCategoryMappingsController : ControllerBase
    {        IProductCategoryMapping oProductCategoryMapping;
        private readonly IMapper _mapper;
        public ProductCategoryMappingsController(IProductCategoryMapping productCategoryMapping, IMapper mapper)
        {
            oProductCategoryMapping = productCategoryMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetProductCategoryMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCategoryMappingDTO>> GetProductCategoryMappingById(long Id)
        {
            TbProductCategoryMapping productCategoryMapping = await oProductCategoryMapping.GetById(Id);

            if (productCategoryMapping == null)
            {
                return NotFound($"ProductCategoryMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ProductCategoryMappingDTO>(productCategoryMapping));
        }        [HttpPost(Name = "AddProductCategoryMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductCategoryMappingDTO>> AddProductCategoryMapping(ProductCategoryMappingDTO newProductCategoryMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productCategoryMapping data.");
            }

            long productCategoryMappingId = await oProductCategoryMapping.Add(_mapper.Map<TbProductCategoryMapping>(newProductCategoryMapping));

            if (productCategoryMappingId <= 0)
            {
                return BadRequest("Failed to add productCategoryMapping.");
            }

            newProductCategoryMapping.Id = productCategoryMappingId;

            return CreatedAtRoute("GetProductCategoryMappingById", new { id = productCategoryMappingId }, newProductCategoryMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateProductCategoryMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCategoryMappingDTO>> UpdateProductCategoryMapping(long Id, ProductCategoryMappingDTO updatedProductCategoryMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productCategoryMapping data.");
            }

            if (!await oProductCategoryMapping.IsExists(Id))
            {
                return NotFound($"ProductCategoryMapping with ID {Id} not found.");
            }

            updatedProductCategoryMapping.Id = Id;

            if (!await oProductCategoryMapping.Update(_mapper.Map<TbProductCategoryMapping>(updatedProductCategoryMapping)))
            {
                return BadRequest("Failed to update productCategoryMapping.");
            }

            return Ok(updatedProductCategoryMapping);
        }        [HttpGet("All", Name = "GetAllProductCategoryMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductCategoryMappingDTO>>> GetAllProductCategoryMappings(int pageNumber = 1, int pageSize = 50)
        {
            var productCategoryMappingsList = await oProductCategoryMapping.GetAll(pageNumber, pageSize);
            if (productCategoryMappingsList.Count == 0)
            {
                return NotFound("No ProductCategoryMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ProductCategoryMappingDTO>>(productCategoryMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsProductCategoryMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsProductCategoryMappingExists(long Id)
        {
            bool exists = await oProductCategoryMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "ProductCategoryMapping Not Found!" });
            }
            return Ok(new { Message = "ProductCategoryMapping Exists" });
        }

        [HttpGet("Count", Name = "GetProductCategoryMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetProductCategoryMappingsCount()
        {
            return Ok(await oProductCategoryMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteProductCategoryMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductCategoryMapping(long Id)
        {        
            if (await oProductCategoryMapping.Delete(Id))
            {
                return Ok($"ProductCategoryMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"ProductCategoryMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}