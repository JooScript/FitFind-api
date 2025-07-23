using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/TicketReplies")]
    [ApiController]
    public class TicketRepliesController : ControllerBase
    {        ITicketReply oTicketReply;
        private readonly IMapper _mapper;
        public TicketRepliesController(ITicketReply ticketReply, IMapper mapper)
        {
            oTicketReply = ticketReply;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetTicketReplyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TicketReplyDTO>> GetTicketReplyById(long Id)
        {
            TbTicketReply ticketReply = await oTicketReply.GetById(Id);

            if (ticketReply == null)
            {
                return NotFound($"TicketReply with ID {Id} not found.");
            }

            return Ok(_mapper.Map<TicketReplyDTO>(ticketReply));
        }        [HttpPost(Name = "AddTicketReply")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TicketReplyDTO>> AddTicketReply(TicketReplyDTO newTicketReply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid ticketReply data.");
            }

            long ticketReplyId = await oTicketReply.Add(_mapper.Map<TbTicketReply>(newTicketReply));

            if (ticketReplyId <= 0)
            {
                return BadRequest("Failed to add ticketReply.");
            }

            newTicketReply.Id = ticketReplyId;

            return CreatedAtRoute("GetTicketReplyById", new { id = ticketReplyId }, newTicketReply);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateTicketReply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TicketReplyDTO>> UpdateTicketReply(long Id, TicketReplyDTO updatedTicketReply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid ticketReply data.");
            }

            if (!await oTicketReply.IsExists(Id))
            {
                return NotFound($"TicketReply with ID {Id} not found.");
            }

            updatedTicketReply.Id = Id;

            if (!await oTicketReply.Update(_mapper.Map<TbTicketReply>(updatedTicketReply)))
            {
                return BadRequest("Failed to update ticketReply.");
            }

            return Ok(updatedTicketReply);
        }        [HttpGet("All", Name = "GetAllTicketReplies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TicketReplyDTO>>> GetAllTicketReplies(int pageNumber = 1, int pageSize = 50)
        {
            var ticketRepliesList = await oTicketReply.GetAll(pageNumber, pageSize);
            if (ticketRepliesList.Count == 0)
            {
                return NotFound("No TicketReplies Found!");
            }
            return Ok(_mapper.Map<IEnumerable<TicketReplyDTO>>(ticketRepliesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsTicketReplyExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsTicketReplyExists(long Id)
        {
            bool exists = await oTicketReply.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "TicketReply Not Found!" });
            }
            return Ok(new { Message = "TicketReply Exists" });
        }

        [HttpGet("Count", Name = "GetTicketRepliesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetTicketRepliesCount()
        {
            return Ok(await oTicketReply.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteTicketReply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTicketReply(long Id)
        {        
            if (await oTicketReply.Delete(Id))
            {
                return Ok($"TicketReply with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"TicketReply with ID {Id} not found. No rows deleted!");
            }
        }

    }
}