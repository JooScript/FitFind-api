using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/CampaignProductMappings")]
    [ApiController]
    public class CampaignProductMappingsController : ControllerBase
    {        ICampaignProductMapping oCampaignProductMapping;
        private readonly IMapper _mapper;
        public CampaignProductMappingsController(ICampaignProductMapping campaignProductMapping, IMapper mapper)
        {
            oCampaignProductMapping = campaignProductMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetCampaignProductMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampaignProductMappingDTO>> GetCampaignProductMappingById(long Id)
        {
            TbCampaignProductMapping campaignProductMapping = await oCampaignProductMapping.GetById(Id);

            if (campaignProductMapping == null)
            {
                return NotFound($"CampaignProductMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<CampaignProductMappingDTO>(campaignProductMapping));
        }        [HttpPost(Name = "AddCampaignProductMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CampaignProductMappingDTO>> AddCampaignProductMapping(CampaignProductMappingDTO newCampaignProductMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid campaignProductMapping data.");
            }

            long campaignProductMappingId = await oCampaignProductMapping.Add(_mapper.Map<TbCampaignProductMapping>(newCampaignProductMapping));

            if (campaignProductMappingId <= 0)
            {
                return BadRequest("Failed to add campaignProductMapping.");
            }

            newCampaignProductMapping.Id = campaignProductMappingId;

            return CreatedAtRoute("GetCampaignProductMappingById", new { id = campaignProductMappingId }, newCampaignProductMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateCampaignProductMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampaignProductMappingDTO>> UpdateCampaignProductMapping(long Id, CampaignProductMappingDTO updatedCampaignProductMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid campaignProductMapping data.");
            }

            if (!await oCampaignProductMapping.IsExists(Id))
            {
                return NotFound($"CampaignProductMapping with ID {Id} not found.");
            }

            updatedCampaignProductMapping.Id = Id;

            if (!await oCampaignProductMapping.Update(_mapper.Map<TbCampaignProductMapping>(updatedCampaignProductMapping)))
            {
                return BadRequest("Failed to update campaignProductMapping.");
            }

            return Ok(updatedCampaignProductMapping);
        }        [HttpGet("All", Name = "GetAllCampaignProductMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CampaignProductMappingDTO>>> GetAllCampaignProductMappings(int pageNumber = 1, int pageSize = 50)
        {
            var campaignProductMappingsList = await oCampaignProductMapping.GetAll(pageNumber, pageSize);
            if (campaignProductMappingsList.Count == 0)
            {
                return NotFound("No CampaignProductMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<CampaignProductMappingDTO>>(campaignProductMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsCampaignProductMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsCampaignProductMappingExists(long Id)
        {
            bool exists = await oCampaignProductMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "CampaignProductMapping Not Found!" });
            }
            return Ok(new { Message = "CampaignProductMapping Exists" });
        }

        [HttpGet("Count", Name = "GetCampaignProductMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetCampaignProductMappingsCount()
        {
            return Ok(await oCampaignProductMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteCampaignProductMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCampaignProductMapping(long Id)
        {        
            if (await oCampaignProductMapping.Delete(Id))
            {
                return Ok($"CampaignProductMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"CampaignProductMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}