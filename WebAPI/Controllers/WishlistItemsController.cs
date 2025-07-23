using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/WishlistItems")]
    [ApiController]
    public class WishlistItemsController : ControllerBase
    {        IWishlistItem oWishlistItem;
        private readonly IMapper _mapper;
        public WishlistItemsController(IWishlistItem wishlistItem, IMapper mapper)
        {
            oWishlistItem = wishlistItem;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetWishlistItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishlistItemDTO>> GetWishlistItemById(long Id)
        {
            TbWishlistItem wishlistItem = await oWishlistItem.GetById(Id);

            if (wishlistItem == null)
            {
                return NotFound($"WishlistItem with ID {Id} not found.");
            }

            return Ok(_mapper.Map<WishlistItemDTO>(wishlistItem));
        }        [HttpPost(Name = "AddWishlistItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WishlistItemDTO>> AddWishlistItem(WishlistItemDTO newWishlistItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid wishlistItem data.");
            }

            long wishlistItemId = await oWishlistItem.Add(_mapper.Map<TbWishlistItem>(newWishlistItem));

            if (wishlistItemId <= 0)
            {
                return BadRequest("Failed to add wishlistItem.");
            }

            newWishlistItem.Id = wishlistItemId;

            return CreatedAtRoute("GetWishlistItemById", new { id = wishlistItemId }, newWishlistItem);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateWishlistItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishlistItemDTO>> UpdateWishlistItem(long Id, WishlistItemDTO updatedWishlistItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid wishlistItem data.");
            }

            if (!await oWishlistItem.IsExists(Id))
            {
                return NotFound($"WishlistItem with ID {Id} not found.");
            }

            updatedWishlistItem.Id = Id;

            if (!await oWishlistItem.Update(_mapper.Map<TbWishlistItem>(updatedWishlistItem)))
            {
                return BadRequest("Failed to update wishlistItem.");
            }

            return Ok(updatedWishlistItem);
        }        [HttpGet("All", Name = "GetAllWishlistItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WishlistItemDTO>>> GetAllWishlistItems(int pageNumber = 1, int pageSize = 50)
        {
            var wishlistItemsList = await oWishlistItem.GetAll(pageNumber, pageSize);
            if (wishlistItemsList.Count == 0)
            {
                return NotFound("No WishlistItems Found!");
            }
            return Ok(_mapper.Map<IEnumerable<WishlistItemDTO>>(wishlistItemsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsWishlistItemExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsWishlistItemExists(long Id)
        {
            bool exists = await oWishlistItem.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "WishlistItem Not Found!" });
            }
            return Ok(new { Message = "WishlistItem Exists" });
        }

        [HttpGet("Count", Name = "GetWishlistItemsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetWishlistItemsCount()
        {
            return Ok(await oWishlistItem.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteWishlistItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWishlistItem(long Id)
        {        
            if (await oWishlistItem.Delete(Id))
            {
                return Ok($"WishlistItem with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"WishlistItem with ID {Id} not found. No rows deleted!");
            }
        }

    }
}