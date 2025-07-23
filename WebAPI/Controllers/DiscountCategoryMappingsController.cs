using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/DiscountCategoryMappings")]
    [ApiController]
    public class DiscountCategoryMappingsController : ControllerBase
    {        IDiscountCategoryMapping oDiscountCategoryMapping;
        private readonly IMapper _mapper;
        public DiscountCategoryMappingsController(IDiscountCategoryMapping discountCategoryMapping, IMapper mapper)
        {
            oDiscountCategoryMapping = discountCategoryMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetDiscountCategoryMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountCategoryMappingDTO>> GetDiscountCategoryMappingById(long Id)
        {
            TbDiscountCategoryMapping discountCategoryMapping = await oDiscountCategoryMapping.GetById(Id);

            if (discountCategoryMapping == null)
            {
                return NotFound($"DiscountCategoryMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<DiscountCategoryMappingDTO>(discountCategoryMapping));
        }        [HttpPost(Name = "AddDiscountCategoryMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DiscountCategoryMappingDTO>> AddDiscountCategoryMapping(DiscountCategoryMappingDTO newDiscountCategoryMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid discountCategoryMapping data.");
            }

            long discountCategoryMappingId = await oDiscountCategoryMapping.Add(_mapper.Map<TbDiscountCategoryMapping>(newDiscountCategoryMapping));

            if (discountCategoryMappingId <= 0)
            {
                return BadRequest("Failed to add discountCategoryMapping.");
            }

            newDiscountCategoryMapping.Id = discountCategoryMappingId;

            return CreatedAtRoute("GetDiscountCategoryMappingById", new { id = discountCategoryMappingId }, newDiscountCategoryMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateDiscountCategoryMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountCategoryMappingDTO>> UpdateDiscountCategoryMapping(long Id, DiscountCategoryMappingDTO updatedDiscountCategoryMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid discountCategoryMapping data.");
            }

            if (!await oDiscountCategoryMapping.IsExists(Id))
            {
                return NotFound($"DiscountCategoryMapping with ID {Id} not found.");
            }

            updatedDiscountCategoryMapping.Id = Id;

            if (!await oDiscountCategoryMapping.Update(_mapper.Map<TbDiscountCategoryMapping>(updatedDiscountCategoryMapping)))
            {
                return BadRequest("Failed to update discountCategoryMapping.");
            }

            return Ok(updatedDiscountCategoryMapping);
        }        [HttpGet("All", Name = "GetAllDiscountCategoryMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DiscountCategoryMappingDTO>>> GetAllDiscountCategoryMappings(int pageNumber = 1, int pageSize = 50)
        {
            var discountCategoryMappingsList = await oDiscountCategoryMapping.GetAll(pageNumber, pageSize);
            if (discountCategoryMappingsList.Count == 0)
            {
                return NotFound("No DiscountCategoryMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<DiscountCategoryMappingDTO>>(discountCategoryMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsDiscountCategoryMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsDiscountCategoryMappingExists(long Id)
        {
            bool exists = await oDiscountCategoryMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "DiscountCategoryMapping Not Found!" });
            }
            return Ok(new { Message = "DiscountCategoryMapping Exists" });
        }

        [HttpGet("Count", Name = "GetDiscountCategoryMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetDiscountCategoryMappingsCount()
        {
            return Ok(await oDiscountCategoryMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteDiscountCategoryMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteDiscountCategoryMapping(long Id)
        {        
            if (await oDiscountCategoryMapping.Delete(Id))
            {
                return Ok($"DiscountCategoryMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"DiscountCategoryMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}