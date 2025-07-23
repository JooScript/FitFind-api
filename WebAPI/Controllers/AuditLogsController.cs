using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/AuditLogs")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {        IAuditLog oAuditLog;
        private readonly IMapper _mapper;
        public AuditLogsController(IAuditLog auditLog, IMapper mapper)
        {
            oAuditLog = auditLog;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetAuditLogById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditLogDTO>> GetAuditLogById(long Id)
        {
            TbAuditLog auditLog = await oAuditLog.GetById(Id);

            if (auditLog == null)
            {
                return NotFound($"AuditLog with ID {Id} not found.");
            }

            return Ok(_mapper.Map<AuditLogDTO>(auditLog));
        }        [HttpPost(Name = "AddAuditLog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuditLogDTO>> AddAuditLog(AuditLogDTO newAuditLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid auditLog data.");
            }

            long auditLogId = await oAuditLog.Add(_mapper.Map<TbAuditLog>(newAuditLog));

            if (auditLogId <= 0)
            {
                return BadRequest("Failed to add auditLog.");
            }

            newAuditLog.Id = auditLogId;

            return CreatedAtRoute("GetAuditLogById", new { id = auditLogId }, newAuditLog);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateAuditLog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditLogDTO>> UpdateAuditLog(long Id, AuditLogDTO updatedAuditLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid auditLog data.");
            }

            if (!await oAuditLog.IsExists(Id))
            {
                return NotFound($"AuditLog with ID {Id} not found.");
            }

            updatedAuditLog.Id = Id;

            if (!await oAuditLog.Update(_mapper.Map<TbAuditLog>(updatedAuditLog)))
            {
                return BadRequest("Failed to update auditLog.");
            }

            return Ok(updatedAuditLog);
        }        [HttpGet("All", Name = "GetAllAuditLogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AuditLogDTO>>> GetAllAuditLogs(int pageNumber = 1, int pageSize = 50)
        {
            var auditLogsList = await oAuditLog.GetAll(pageNumber, pageSize);
            if (auditLogsList.Count == 0)
            {
                return NotFound("No AuditLogs Found!");
            }
            return Ok(_mapper.Map<IEnumerable<AuditLogDTO>>(auditLogsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsAuditLogExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsAuditLogExists(long Id)
        {
            bool exists = await oAuditLog.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "AuditLog Not Found!" });
            }
            return Ok(new { Message = "AuditLog Exists" });
        }

        [HttpGet("Count", Name = "GetAuditLogsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetAuditLogsCount()
        {
            return Ok(await oAuditLog.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteAuditLog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAuditLog(long Id)
        {        
            if (await oAuditLog.Delete(Id))
            {
                return Ok($"AuditLog with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"AuditLog with ID {Id} not found. No rows deleted!");
            }
        }

    }
}