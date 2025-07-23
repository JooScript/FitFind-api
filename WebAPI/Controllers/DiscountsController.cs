using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Discounts")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {        IDiscount oDiscount;
        private readonly IMapper _mapper;
        public DiscountsController(IDiscount discount, IMapper mapper)
        {
            oDiscount = discount;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetDiscountById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountDTO>> GetDiscountById(long Id)
        {
            TbDiscount discount = await oDiscount.GetById(Id);

            if (discount == null)
            {
                return NotFound($"Discount with ID {Id} not found.");
            }

            return Ok(_mapper.Map<DiscountDTO>(discount));
        }        [HttpPost(Name = "AddDiscount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DiscountDTO>> AddDiscount(DiscountDTO newDiscount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid discount data.");
            }

            long discountId = await oDiscount.Add(_mapper.Map<TbDiscount>(newDiscount));

            if (discountId <= 0)
            {
                return BadRequest("Failed to add discount.");
            }

            newDiscount.Id = discountId;

            return CreatedAtRoute("GetDiscountById", new { id = discountId }, newDiscount);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateDiscount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountDTO>> UpdateDiscount(long Id, DiscountDTO updatedDiscount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid discount data.");
            }

            if (!await oDiscount.IsExists(Id))
            {
                return NotFound($"Discount with ID {Id} not found.");
            }

            updatedDiscount.Id = Id;

            if (!await oDiscount.Update(_mapper.Map<TbDiscount>(updatedDiscount)))
            {
                return BadRequest("Failed to update discount.");
            }

            return Ok(updatedDiscount);
        }        [HttpGet("All", Name = "GetAllDiscounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DiscountDTO>>> GetAllDiscounts(int pageNumber = 1, int pageSize = 50)
        {
            var discountsList = await oDiscount.GetAll(pageNumber, pageSize);
            if (discountsList.Count == 0)
            {
                return NotFound("No Discounts Found!");
            }
            return Ok(_mapper.Map<IEnumerable<DiscountDTO>>(discountsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsDiscountExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsDiscountExists(long Id)
        {
            bool exists = await oDiscount.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Discount Not Found!" });
            }
            return Ok(new { Message = "Discount Exists" });
        }

        [HttpGet("Count", Name = "GetDiscountsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetDiscountsCount()
        {
            return Ok(await oDiscount.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteDiscount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteDiscount(long Id)
        {        
            if (await oDiscount.Delete(Id))
            {
                return Ok($"Discount with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Discount with ID {Id} not found. No rows deleted!");
            }
        }

    }
}