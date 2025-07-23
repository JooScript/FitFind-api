using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Campaigns")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {        ICampaign oCampaign;
        private readonly IMapper _mapper;
        public CampaignsController(ICampaign campaign, IMapper mapper)
        {
            oCampaign = campaign;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetCampaignById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampaignDTO>> GetCampaignById(long Id)
        {
            TbCampaign campaign = await oCampaign.GetById(Id);

            if (campaign == null)
            {
                return NotFound($"Campaign with ID {Id} not found.");
            }

            return Ok(_mapper.Map<CampaignDTO>(campaign));
        }        [HttpPost(Name = "AddCampaign")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CampaignDTO>> AddCampaign(CampaignDTO newCampaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid campaign data.");
            }

            long campaignId = await oCampaign.Add(_mapper.Map<TbCampaign>(newCampaign));

            if (campaignId <= 0)
            {
                return BadRequest("Failed to add campaign.");
            }

            newCampaign.Id = campaignId;

            return CreatedAtRoute("GetCampaignById", new { id = campaignId }, newCampaign);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateCampaign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampaignDTO>> UpdateCampaign(long Id, CampaignDTO updatedCampaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid campaign data.");
            }

            if (!await oCampaign.IsExists(Id))
            {
                return NotFound($"Campaign with ID {Id} not found.");
            }

            updatedCampaign.Id = Id;

            if (!await oCampaign.Update(_mapper.Map<TbCampaign>(updatedCampaign)))
            {
                return BadRequest("Failed to update campaign.");
            }

            return Ok(updatedCampaign);
        }        [HttpGet("All", Name = "GetAllCampaigns")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CampaignDTO>>> GetAllCampaigns(int pageNumber = 1, int pageSize = 50)
        {
            var campaignsList = await oCampaign.GetAll(pageNumber, pageSize);
            if (campaignsList.Count == 0)
            {
                return NotFound("No Campaigns Found!");
            }
            return Ok(_mapper.Map<IEnumerable<CampaignDTO>>(campaignsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsCampaignExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsCampaignExists(long Id)
        {
            bool exists = await oCampaign.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Campaign Not Found!" });
            }
            return Ok(new { Message = "Campaign Exists" });
        }

        [HttpGet("Count", Name = "GetCampaignsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetCampaignsCount()
        {
            return Ok(await oCampaign.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteCampaign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCampaign(long Id)
        {        
            if (await oCampaign.Delete(Id))
            {
                return Ok($"Campaign with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Campaign with ID {Id} not found. No rows deleted!");
            }
        }

    }
}