using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/SupportTickets")]
    [ApiController]
    public class SupportTicketsController : ControllerBase
    {        ISupportTicket oSupportTicket;
        private readonly IMapper _mapper;
        public SupportTicketsController(ISupportTicket supportTicket, IMapper mapper)
        {
            oSupportTicket = supportTicket;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetSupportTicketById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SupportTicketDTO>> GetSupportTicketById(long Id)
        {
            TbSupportTicket supportTicket = await oSupportTicket.GetById(Id);

            if (supportTicket == null)
            {
                return NotFound($"SupportTicket with ID {Id} not found.");
            }

            return Ok(_mapper.Map<SupportTicketDTO>(supportTicket));
        }        [HttpPost(Name = "AddSupportTicket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SupportTicketDTO>> AddSupportTicket(SupportTicketDTO newSupportTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid supportTicket data.");
            }

            long supportTicketId = await oSupportTicket.Add(_mapper.Map<TbSupportTicket>(newSupportTicket));

            if (supportTicketId <= 0)
            {
                return BadRequest("Failed to add supportTicket.");
            }

            newSupportTicket.Id = supportTicketId;

            return CreatedAtRoute("GetSupportTicketById", new { id = supportTicketId }, newSupportTicket);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateSupportTicket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SupportTicketDTO>> UpdateSupportTicket(long Id, SupportTicketDTO updatedSupportTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid supportTicket data.");
            }

            if (!await oSupportTicket.IsExists(Id))
            {
                return NotFound($"SupportTicket with ID {Id} not found.");
            }

            updatedSupportTicket.Id = Id;

            if (!await oSupportTicket.Update(_mapper.Map<TbSupportTicket>(updatedSupportTicket)))
            {
                return BadRequest("Failed to update supportTicket.");
            }

            return Ok(updatedSupportTicket);
        }        [HttpGet("All", Name = "GetAllSupportTickets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SupportTicketDTO>>> GetAllSupportTickets(int pageNumber = 1, int pageSize = 50)
        {
            var supportTicketsList = await oSupportTicket.GetAll(pageNumber, pageSize);
            if (supportTicketsList.Count == 0)
            {
                return NotFound("No SupportTickets Found!");
            }
            return Ok(_mapper.Map<IEnumerable<SupportTicketDTO>>(supportTicketsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsSupportTicketExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsSupportTicketExists(long Id)
        {
            bool exists = await oSupportTicket.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "SupportTicket Not Found!" });
            }
            return Ok(new { Message = "SupportTicket Exists" });
        }

        [HttpGet("Count", Name = "GetSupportTicketsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetSupportTicketsCount()
        {
            return Ok(await oSupportTicket.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteSupportTicket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSupportTicket(long Id)
        {        
            if (await oSupportTicket.Delete(Id))
            {
                return Ok($"SupportTicket with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"SupportTicket with ID {Id} not found. No rows deleted!");
            }
        }

    }
}