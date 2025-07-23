using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {        ITag oTag;
        private readonly IMapper _mapper;
        public TagsController(ITag tag, IMapper mapper)
        {
            oTag = tag;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetTagById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagDTO>> GetTagById(long Id)
        {
            TbTag tag = await oTag.GetById(Id);

            if (tag == null)
            {
                return NotFound($"Tag with ID {Id} not found.");
            }

            return Ok(_mapper.Map<TagDTO>(tag));
        }        [HttpPost(Name = "AddTag")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TagDTO>> AddTag(TagDTO newTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid tag data.");
            }

            long tagId = await oTag.Add(_mapper.Map<TbTag>(newTag));

            if (tagId <= 0)
            {
                return BadRequest("Failed to add tag.");
            }

            newTag.Id = tagId;

            return CreatedAtRoute("GetTagById", new { id = tagId }, newTag);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateTag")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagDTO>> UpdateTag(long Id, TagDTO updatedTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid tag data.");
            }

            if (!await oTag.IsExists(Id))
            {
                return NotFound($"Tag with ID {Id} not found.");
            }

            updatedTag.Id = Id;

            if (!await oTag.Update(_mapper.Map<TbTag>(updatedTag)))
            {
                return BadRequest("Failed to update tag.");
            }

            return Ok(updatedTag);
        }        [HttpGet("All", Name = "GetAllTags")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetAllTags(int pageNumber = 1, int pageSize = 50)
        {
            var tagsList = await oTag.GetAll(pageNumber, pageSize);
            if (tagsList.Count == 0)
            {
                return NotFound("No Tags Found!");
            }
            return Ok(_mapper.Map<IEnumerable<TagDTO>>(tagsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsTagExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsTagExists(long Id)
        {
            bool exists = await oTag.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Tag Not Found!" });
            }
            return Ok(new { Message = "Tag Exists" });
        }

        [HttpGet("Count", Name = "GetTagsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetTagsCount()
        {
            return Ok(await oTag.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteTag")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTag(long Id)
        {        
            if (await oTag.Delete(Id))
            {
                return Ok($"Tag with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Tag with ID {Id} not found. No rows deleted!");
            }
        }

    }
}