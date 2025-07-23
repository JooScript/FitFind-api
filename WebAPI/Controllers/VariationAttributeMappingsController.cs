using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/VariationAttributeMappings")]
    [ApiController]
    public class VariationAttributeMappingsController : ControllerBase
    {        IVariationAttributeMapping oVariationAttributeMapping;
        private readonly IMapper _mapper;
        public VariationAttributeMappingsController(IVariationAttributeMapping variationAttributeMapping, IMapper mapper)
        {
            oVariationAttributeMapping = variationAttributeMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetVariationAttributeMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VariationAttributeMappingDTO>> GetVariationAttributeMappingById(long Id)
        {
            TbVariationAttributeMapping variationAttributeMapping = await oVariationAttributeMapping.GetById(Id);

            if (variationAttributeMapping == null)
            {
                return NotFound($"VariationAttributeMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<VariationAttributeMappingDTO>(variationAttributeMapping));
        }        [HttpPost(Name = "AddVariationAttributeMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VariationAttributeMappingDTO>> AddVariationAttributeMapping(VariationAttributeMappingDTO newVariationAttributeMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid variationAttributeMapping data.");
            }

            long variationAttributeMappingId = await oVariationAttributeMapping.Add(_mapper.Map<TbVariationAttributeMapping>(newVariationAttributeMapping));

            if (variationAttributeMappingId <= 0)
            {
                return BadRequest("Failed to add variationAttributeMapping.");
            }

            newVariationAttributeMapping.Id = variationAttributeMappingId;

            return CreatedAtRoute("GetVariationAttributeMappingById", new { id = variationAttributeMappingId }, newVariationAttributeMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateVariationAttributeMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VariationAttributeMappingDTO>> UpdateVariationAttributeMapping(long Id, VariationAttributeMappingDTO updatedVariationAttributeMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid variationAttributeMapping data.");
            }

            if (!await oVariationAttributeMapping.IsExists(Id))
            {
                return NotFound($"VariationAttributeMapping with ID {Id} not found.");
            }

            updatedVariationAttributeMapping.Id = Id;

            if (!await oVariationAttributeMapping.Update(_mapper.Map<TbVariationAttributeMapping>(updatedVariationAttributeMapping)))
            {
                return BadRequest("Failed to update variationAttributeMapping.");
            }

            return Ok(updatedVariationAttributeMapping);
        }        [HttpGet("All", Name = "GetAllVariationAttributeMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<VariationAttributeMappingDTO>>> GetAllVariationAttributeMappings(int pageNumber = 1, int pageSize = 50)
        {
            var variationAttributeMappingsList = await oVariationAttributeMapping.GetAll(pageNumber, pageSize);
            if (variationAttributeMappingsList.Count == 0)
            {
                return NotFound("No VariationAttributeMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<VariationAttributeMappingDTO>>(variationAttributeMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsVariationAttributeMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsVariationAttributeMappingExists(long Id)
        {
            bool exists = await oVariationAttributeMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "VariationAttributeMapping Not Found!" });
            }
            return Ok(new { Message = "VariationAttributeMapping Exists" });
        }

        [HttpGet("Count", Name = "GetVariationAttributeMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetVariationAttributeMappingsCount()
        {
            return Ok(await oVariationAttributeMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteVariationAttributeMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVariationAttributeMapping(long Id)
        {        
            if (await oVariationAttributeMapping.Delete(Id))
            {
                return Ok($"VariationAttributeMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"VariationAttributeMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}