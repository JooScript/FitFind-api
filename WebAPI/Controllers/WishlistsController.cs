using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Wishlists")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {        IWishlist oWishlist;
        private readonly IMapper _mapper;
        public WishlistsController(IWishlist wishlist, IMapper mapper)
        {
            oWishlist = wishlist;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetWishlistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishlistDTO>> GetWishlistById(long Id)
        {
            TbWishlist wishlist = await oWishlist.GetById(Id);

            if (wishlist == null)
            {
                return NotFound($"Wishlist with ID {Id} not found.");
            }

            return Ok(_mapper.Map<WishlistDTO>(wishlist));
        }        [HttpPost(Name = "AddWishlist")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WishlistDTO>> AddWishlist(WishlistDTO newWishlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid wishlist data.");
            }

            long wishlistId = await oWishlist.Add(_mapper.Map<TbWishlist>(newWishlist));

            if (wishlistId <= 0)
            {
                return BadRequest("Failed to add wishlist.");
            }

            newWishlist.Id = wishlistId;

            return CreatedAtRoute("GetWishlistById", new { id = wishlistId }, newWishlist);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateWishlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WishlistDTO>> UpdateWishlist(long Id, WishlistDTO updatedWishlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid wishlist data.");
            }

            if (!await oWishlist.IsExists(Id))
            {
                return NotFound($"Wishlist with ID {Id} not found.");
            }

            updatedWishlist.Id = Id;

            if (!await oWishlist.Update(_mapper.Map<TbWishlist>(updatedWishlist)))
            {
                return BadRequest("Failed to update wishlist.");
            }

            return Ok(updatedWishlist);
        }        [HttpGet("All", Name = "GetAllWishlists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WishlistDTO>>> GetAllWishlists(int pageNumber = 1, int pageSize = 50)
        {
            var wishlistsList = await oWishlist.GetAll(pageNumber, pageSize);
            if (wishlistsList.Count == 0)
            {
                return NotFound("No Wishlists Found!");
            }
            return Ok(_mapper.Map<IEnumerable<WishlistDTO>>(wishlistsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsWishlistExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsWishlistExists(long Id)
        {
            bool exists = await oWishlist.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Wishlist Not Found!" });
            }
            return Ok(new { Message = "Wishlist Exists" });
        }

        [HttpGet("Count", Name = "GetWishlistsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetWishlistsCount()
        {
            return Ok(await oWishlist.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteWishlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWishlist(long Id)
        {        
            if (await oWishlist.Delete(Id))
            {
                return Ok($"Wishlist with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Wishlist with ID {Id} not found. No rows deleted!");
            }
        }

    }
}