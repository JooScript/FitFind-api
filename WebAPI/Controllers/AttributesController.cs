using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Attributes")]
    [ApiController]
    public class AttributesController : ControllerBase
    {        IAttribute oAttribute;
        private readonly IMapper _mapper;
        public AttributesController(IAttribute attribute, IMapper mapper)
        {
            oAttribute = attribute;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetAttributeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttributeDTO>> GetAttributeById(long Id)
        {
            TbAttribute attribute = await oAttribute.GetById(Id);

            if (attribute == null)
            {
                return NotFound($"Attribute with ID {Id} not found.");
            }

            return Ok(_mapper.Map<AttributeDTO>(attribute));
        }        [HttpPost(Name = "AddAttribute")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AttributeDTO>> AddAttribute(AttributeDTO newAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid attribute data.");
            }

            long attributeId = await oAttribute.Add(_mapper.Map<TbAttribute>(newAttribute));

            if (attributeId <= 0)
            {
                return BadRequest("Failed to add attribute.");
            }

            newAttribute.Id = attributeId;

            return CreatedAtRoute("GetAttributeById", new { id = attributeId }, newAttribute);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateAttribute")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttributeDTO>> UpdateAttribute(long Id, AttributeDTO updatedAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid attribute data.");
            }

            if (!await oAttribute.IsExists(Id))
            {
                return NotFound($"Attribute with ID {Id} not found.");
            }

            updatedAttribute.Id = Id;

            if (!await oAttribute.Update(_mapper.Map<TbAttribute>(updatedAttribute)))
            {
                return BadRequest("Failed to update attribute.");
            }

            return Ok(updatedAttribute);
        }        [HttpGet("All", Name = "GetAllAttributes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AttributeDTO>>> GetAllAttributes(int pageNumber = 1, int pageSize = 50)
        {
            var attributesList = await oAttribute.GetAll(pageNumber, pageSize);
            if (attributesList.Count == 0)
            {
                return NotFound("No Attributes Found!");
            }
            return Ok(_mapper.Map<IEnumerable<AttributeDTO>>(attributesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsAttributeExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsAttributeExists(long Id)
        {
            bool exists = await oAttribute.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Attribute Not Found!" });
            }
            return Ok(new { Message = "Attribute Exists" });
        }

        [HttpGet("Count", Name = "GetAttributesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetAttributesCount()
        {
            return Ok(await oAttribute.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteAttribute")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAttribute(long Id)
        {        
            if (await oAttribute.Delete(Id))
            {
                return Ok($"Attribute with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Attribute with ID {Id} not found. No rows deleted!");
            }
        }

    }
}