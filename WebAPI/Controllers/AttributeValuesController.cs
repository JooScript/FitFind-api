using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/AttributeValues")]
    [ApiController]
    public class AttributeValuesController : ControllerBase
    {        IAttributeValue oAttributeValue;
        private readonly IMapper _mapper;
        public AttributeValuesController(IAttributeValue attributeValue, IMapper mapper)
        {
            oAttributeValue = attributeValue;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetAttributeValueById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttributeValueDTO>> GetAttributeValueById(long Id)
        {
            TbAttributeValue attributeValue = await oAttributeValue.GetById(Id);

            if (attributeValue == null)
            {
                return NotFound($"AttributeValue with ID {Id} not found.");
            }

            return Ok(_mapper.Map<AttributeValueDTO>(attributeValue));
        }        [HttpPost(Name = "AddAttributeValue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AttributeValueDTO>> AddAttributeValue(AttributeValueDTO newAttributeValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid attributeValue data.");
            }

            long attributeValueId = await oAttributeValue.Add(_mapper.Map<TbAttributeValue>(newAttributeValue));

            if (attributeValueId <= 0)
            {
                return BadRequest("Failed to add attributeValue.");
            }

            newAttributeValue.Id = attributeValueId;

            return CreatedAtRoute("GetAttributeValueById", new { id = attributeValueId }, newAttributeValue);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateAttributeValue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AttributeValueDTO>> UpdateAttributeValue(long Id, AttributeValueDTO updatedAttributeValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid attributeValue data.");
            }

            if (!await oAttributeValue.IsExists(Id))
            {
                return NotFound($"AttributeValue with ID {Id} not found.");
            }

            updatedAttributeValue.Id = Id;

            if (!await oAttributeValue.Update(_mapper.Map<TbAttributeValue>(updatedAttributeValue)))
            {
                return BadRequest("Failed to update attributeValue.");
            }

            return Ok(updatedAttributeValue);
        }        [HttpGet("All", Name = "GetAllAttributeValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AttributeValueDTO>>> GetAllAttributeValues(int pageNumber = 1, int pageSize = 50)
        {
            var attributeValuesList = await oAttributeValue.GetAll(pageNumber, pageSize);
            if (attributeValuesList.Count == 0)
            {
                return NotFound("No AttributeValues Found!");
            }
            return Ok(_mapper.Map<IEnumerable<AttributeValueDTO>>(attributeValuesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsAttributeValueExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsAttributeValueExists(long Id)
        {
            bool exists = await oAttributeValue.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "AttributeValue Not Found!" });
            }
            return Ok(new { Message = "AttributeValue Exists" });
        }

        [HttpGet("Count", Name = "GetAttributeValuesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetAttributeValuesCount()
        {
            return Ok(await oAttributeValue.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteAttributeValue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAttributeValue(long Id)
        {        
            if (await oAttributeValue.Delete(Id))
            {
                return Ok($"AttributeValue with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"AttributeValue with ID {Id} not found. No rows deleted!");
            }
        }

    }
}