using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/SeoMeta")]
    [ApiController]
    public class SeoMetaController : ControllerBase
    {        ISeoMetum oSeoMetum;
        private readonly IMapper _mapper;
        public SeoMetaController(ISeoMetum seoMetum, IMapper mapper)
        {
            oSeoMetum = seoMetum;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetSeoMetumById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SeoMetumDTO>> GetSeoMetumById(long Id)
        {
            TbSeoMetum seoMetum = await oSeoMetum.GetById(Id);

            if (seoMetum == null)
            {
                return NotFound($"SeoMetum with ID {Id} not found.");
            }

            return Ok(_mapper.Map<SeoMetumDTO>(seoMetum));
        }        [HttpPost(Name = "AddSeoMetum")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SeoMetumDTO>> AddSeoMetum(SeoMetumDTO newSeoMetum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid seoMetum data.");
            }

            long seoMetumId = await oSeoMetum.Add(_mapper.Map<TbSeoMetum>(newSeoMetum));

            if (seoMetumId <= 0)
            {
                return BadRequest("Failed to add seoMetum.");
            }

            newSeoMetum.Id = seoMetumId;

            return CreatedAtRoute("GetSeoMetumById", new { id = seoMetumId }, newSeoMetum);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateSeoMetum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SeoMetumDTO>> UpdateSeoMetum(long Id, SeoMetumDTO updatedSeoMetum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid seoMetum data.");
            }

            if (!await oSeoMetum.IsExists(Id))
            {
                return NotFound($"SeoMetum with ID {Id} not found.");
            }

            updatedSeoMetum.Id = Id;

            if (!await oSeoMetum.Update(_mapper.Map<TbSeoMetum>(updatedSeoMetum)))
            {
                return BadRequest("Failed to update seoMetum.");
            }

            return Ok(updatedSeoMetum);
        }        [HttpGet("All", Name = "GetAllSeoMeta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SeoMetumDTO>>> GetAllSeoMeta(int pageNumber = 1, int pageSize = 50)
        {
            var seoMetaList = await oSeoMetum.GetAll(pageNumber, pageSize);
            if (seoMetaList.Count == 0)
            {
                return NotFound("No SeoMeta Found!");
            }
            return Ok(_mapper.Map<IEnumerable<SeoMetumDTO>>(seoMetaList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsSeoMetumExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsSeoMetumExists(long Id)
        {
            bool exists = await oSeoMetum.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "SeoMetum Not Found!" });
            }
            return Ok(new { Message = "SeoMetum Exists" });
        }

        [HttpGet("Count", Name = "GetSeoMetaCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetSeoMetaCount()
        {
            return Ok(await oSeoMetum.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteSeoMetum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSeoMetum(long Id)
        {        
            if (await oSeoMetum.Delete(Id))
            {
                return Ok($"SeoMetum with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"SeoMetum with ID {Id} not found. No rows deleted!");
            }
        }

    }
}