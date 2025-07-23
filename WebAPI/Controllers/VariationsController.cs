using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Variations")]
    [ApiController]
    public class VariationsController : ControllerBase
    {        IVariation oVariation;
        private readonly IMapper _mapper;
        public VariationsController(IVariation variation, IMapper mapper)
        {
            oVariation = variation;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetVariationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VariationDTO>> GetVariationById(long Id)
        {
            TbVariation variation = await oVariation.GetById(Id);

            if (variation == null)
            {
                return NotFound($"Variation with ID {Id} not found.");
            }

            return Ok(_mapper.Map<VariationDTO>(variation));
        }        [HttpPost(Name = "AddVariation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VariationDTO>> AddVariation(VariationDTO newVariation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid variation data.");
            }

            long variationId = await oVariation.Add(_mapper.Map<TbVariation>(newVariation));

            if (variationId <= 0)
            {
                return BadRequest("Failed to add variation.");
            }

            newVariation.Id = variationId;

            return CreatedAtRoute("GetVariationById", new { id = variationId }, newVariation);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateVariation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VariationDTO>> UpdateVariation(long Id, VariationDTO updatedVariation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid variation data.");
            }

            if (!await oVariation.IsExists(Id))
            {
                return NotFound($"Variation with ID {Id} not found.");
            }

            updatedVariation.Id = Id;

            if (!await oVariation.Update(_mapper.Map<TbVariation>(updatedVariation)))
            {
                return BadRequest("Failed to update variation.");
            }

            return Ok(updatedVariation);
        }        [HttpGet("All", Name = "GetAllVariations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<VariationDTO>>> GetAllVariations(int pageNumber = 1, int pageSize = 50)
        {
            var variationsList = await oVariation.GetAll(pageNumber, pageSize);
            if (variationsList.Count == 0)
            {
                return NotFound("No Variations Found!");
            }
            return Ok(_mapper.Map<IEnumerable<VariationDTO>>(variationsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsVariationExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsVariationExists(long Id)
        {
            bool exists = await oVariation.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Variation Not Found!" });
            }
            return Ok(new { Message = "Variation Exists" });
        }

        [HttpGet("Count", Name = "GetVariationsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetVariationsCount()
        {
            return Ok(await oVariation.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteVariation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVariation(long Id)
        {        
            if (await oVariation.Delete(Id))
            {
                return Ok($"Variation with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Variation with ID {Id} not found. No rows deleted!");
            }
        }

    }
}