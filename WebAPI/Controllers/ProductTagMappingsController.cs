using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/ProductTagMappings")]
    [ApiController]
    public class ProductTagMappingsController : ControllerBase
    {        IProductTagMapping oProductTagMapping;
        private readonly IMapper _mapper;
        public ProductTagMappingsController(IProductTagMapping productTagMapping, IMapper mapper)
        {
            oProductTagMapping = productTagMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetProductTagMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductTagMappingDTO>> GetProductTagMappingById(long Id)
        {
            TbProductTagMapping productTagMapping = await oProductTagMapping.GetById(Id);

            if (productTagMapping == null)
            {
                return NotFound($"ProductTagMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ProductTagMappingDTO>(productTagMapping));
        }        [HttpPost(Name = "AddProductTagMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductTagMappingDTO>> AddProductTagMapping(ProductTagMappingDTO newProductTagMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productTagMapping data.");
            }

            long productTagMappingId = await oProductTagMapping.Add(_mapper.Map<TbProductTagMapping>(newProductTagMapping));

            if (productTagMappingId <= 0)
            {
                return BadRequest("Failed to add productTagMapping.");
            }

            newProductTagMapping.Id = productTagMappingId;

            return CreatedAtRoute("GetProductTagMappingById", new { id = productTagMappingId }, newProductTagMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateProductTagMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductTagMappingDTO>> UpdateProductTagMapping(long Id, ProductTagMappingDTO updatedProductTagMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productTagMapping data.");
            }

            if (!await oProductTagMapping.IsExists(Id))
            {
                return NotFound($"ProductTagMapping with ID {Id} not found.");
            }

            updatedProductTagMapping.Id = Id;

            if (!await oProductTagMapping.Update(_mapper.Map<TbProductTagMapping>(updatedProductTagMapping)))
            {
                return BadRequest("Failed to update productTagMapping.");
            }

            return Ok(updatedProductTagMapping);
        }        [HttpGet("All", Name = "GetAllProductTagMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductTagMappingDTO>>> GetAllProductTagMappings(int pageNumber = 1, int pageSize = 50)
        {
            var productTagMappingsList = await oProductTagMapping.GetAll(pageNumber, pageSize);
            if (productTagMappingsList.Count == 0)
            {
                return NotFound("No ProductTagMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ProductTagMappingDTO>>(productTagMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsProductTagMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsProductTagMappingExists(long Id)
        {
            bool exists = await oProductTagMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "ProductTagMapping Not Found!" });
            }
            return Ok(new { Message = "ProductTagMapping Exists" });
        }

        [HttpGet("Count", Name = "GetProductTagMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetProductTagMappingsCount()
        {
            return Ok(await oProductTagMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteProductTagMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductTagMapping(long Id)
        {        
            if (await oProductTagMapping.Delete(Id))
            {
                return Ok($"ProductTagMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"ProductTagMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}