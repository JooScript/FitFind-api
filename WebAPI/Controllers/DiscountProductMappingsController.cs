using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/DiscountProductMappings")]
    [ApiController]
    public class DiscountProductMappingsController : ControllerBase
    {        IDiscountProductMapping oDiscountProductMapping;
        private readonly IMapper _mapper;
        public DiscountProductMappingsController(IDiscountProductMapping discountProductMapping, IMapper mapper)
        {
            oDiscountProductMapping = discountProductMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetDiscountProductMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountProductMappingDTO>> GetDiscountProductMappingById(long Id)
        {
            TbDiscountProductMapping discountProductMapping = await oDiscountProductMapping.GetById(Id);

            if (discountProductMapping == null)
            {
                return NotFound($"DiscountProductMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<DiscountProductMappingDTO>(discountProductMapping));
        }        [HttpPost(Name = "AddDiscountProductMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DiscountProductMappingDTO>> AddDiscountProductMapping(DiscountProductMappingDTO newDiscountProductMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid discountProductMapping data.");
            }

            long discountProductMappingId = await oDiscountProductMapping.Add(_mapper.Map<TbDiscountProductMapping>(newDiscountProductMapping));

            if (discountProductMappingId <= 0)
            {
                return BadRequest("Failed to add discountProductMapping.");
            }

            newDiscountProductMapping.Id = discountProductMappingId;

            return CreatedAtRoute("GetDiscountProductMappingById", new { id = discountProductMappingId }, newDiscountProductMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateDiscountProductMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountProductMappingDTO>> UpdateDiscountProductMapping(long Id, DiscountProductMappingDTO updatedDiscountProductMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid discountProductMapping data.");
            }

            if (!await oDiscountProductMapping.IsExists(Id))
            {
                return NotFound($"DiscountProductMapping with ID {Id} not found.");
            }

            updatedDiscountProductMapping.Id = Id;

            if (!await oDiscountProductMapping.Update(_mapper.Map<TbDiscountProductMapping>(updatedDiscountProductMapping)))
            {
                return BadRequest("Failed to update discountProductMapping.");
            }

            return Ok(updatedDiscountProductMapping);
        }        [HttpGet("All", Name = "GetAllDiscountProductMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DiscountProductMappingDTO>>> GetAllDiscountProductMappings(int pageNumber = 1, int pageSize = 50)
        {
            var discountProductMappingsList = await oDiscountProductMapping.GetAll(pageNumber, pageSize);
            if (discountProductMappingsList.Count == 0)
            {
                return NotFound("No DiscountProductMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<DiscountProductMappingDTO>>(discountProductMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsDiscountProductMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsDiscountProductMappingExists(long Id)
        {
            bool exists = await oDiscountProductMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "DiscountProductMapping Not Found!" });
            }
            return Ok(new { Message = "DiscountProductMapping Exists" });
        }

        [HttpGet("Count", Name = "GetDiscountProductMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetDiscountProductMappingsCount()
        {
            return Ok(await oDiscountProductMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteDiscountProductMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteDiscountProductMapping(long Id)
        {        
            if (await oDiscountProductMapping.Delete(Id))
            {
                return Ok($"DiscountProductMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"DiscountProductMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}