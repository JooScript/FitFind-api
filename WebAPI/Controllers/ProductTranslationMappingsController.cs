using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/ProductTranslationMappings")]
    [ApiController]
    public class ProductTranslationMappingsController : ControllerBase
    {        IProductTranslationMapping oProductTranslationMapping;
        private readonly IMapper _mapper;
        public ProductTranslationMappingsController(IProductTranslationMapping productTranslationMapping, IMapper mapper)
        {
            oProductTranslationMapping = productTranslationMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetProductTranslationMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductTranslationMappingDTO>> GetProductTranslationMappingById(long Id)
        {
            TbProductTranslationMapping productTranslationMapping = await oProductTranslationMapping.GetById(Id);

            if (productTranslationMapping == null)
            {
                return NotFound($"ProductTranslationMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ProductTranslationMappingDTO>(productTranslationMapping));
        }        [HttpPost(Name = "AddProductTranslationMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductTranslationMappingDTO>> AddProductTranslationMapping(ProductTranslationMappingDTO newProductTranslationMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productTranslationMapping data.");
            }

            long productTranslationMappingId = await oProductTranslationMapping.Add(_mapper.Map<TbProductTranslationMapping>(newProductTranslationMapping));

            if (productTranslationMappingId <= 0)
            {
                return BadRequest("Failed to add productTranslationMapping.");
            }

            newProductTranslationMapping.Id = productTranslationMappingId;

            return CreatedAtRoute("GetProductTranslationMappingById", new { id = productTranslationMappingId }, newProductTranslationMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateProductTranslationMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductTranslationMappingDTO>> UpdateProductTranslationMapping(long Id, ProductTranslationMappingDTO updatedProductTranslationMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid productTranslationMapping data.");
            }

            if (!await oProductTranslationMapping.IsExists(Id))
            {
                return NotFound($"ProductTranslationMapping with ID {Id} not found.");
            }

            updatedProductTranslationMapping.Id = Id;

            if (!await oProductTranslationMapping.Update(_mapper.Map<TbProductTranslationMapping>(updatedProductTranslationMapping)))
            {
                return BadRequest("Failed to update productTranslationMapping.");
            }

            return Ok(updatedProductTranslationMapping);
        }        [HttpGet("All", Name = "GetAllProductTranslationMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductTranslationMappingDTO>>> GetAllProductTranslationMappings(int pageNumber = 1, int pageSize = 50)
        {
            var productTranslationMappingsList = await oProductTranslationMapping.GetAll(pageNumber, pageSize);
            if (productTranslationMappingsList.Count == 0)
            {
                return NotFound("No ProductTranslationMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ProductTranslationMappingDTO>>(productTranslationMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsProductTranslationMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsProductTranslationMappingExists(long Id)
        {
            bool exists = await oProductTranslationMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "ProductTranslationMapping Not Found!" });
            }
            return Ok(new { Message = "ProductTranslationMapping Exists" });
        }

        [HttpGet("Count", Name = "GetProductTranslationMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetProductTranslationMappingsCount()
        {
            return Ok(await oProductTranslationMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteProductTranslationMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductTranslationMapping(long Id)
        {        
            if (await oProductTranslationMapping.Delete(Id))
            {
                return Ok($"ProductTranslationMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"ProductTranslationMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}