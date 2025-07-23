using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/CartItems")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {        ICartItem oCartItem;
        private readonly IMapper _mapper;
        public CartItemsController(ICartItem cartItem, IMapper mapper)
        {
            oCartItem = cartItem;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetCartItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartItemDTO>> GetCartItemById(long Id)
        {
            TbCartItem cartItem = await oCartItem.GetById(Id);

            if (cartItem == null)
            {
                return NotFound($"CartItem with ID {Id} not found.");
            }

            return Ok(_mapper.Map<CartItemDTO>(cartItem));
        }        [HttpPost(Name = "AddCartItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartItemDTO>> AddCartItem(CartItemDTO newCartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid cartItem data.");
            }

            long cartItemId = await oCartItem.Add(_mapper.Map<TbCartItem>(newCartItem));

            if (cartItemId <= 0)
            {
                return BadRequest("Failed to add cartItem.");
            }

            newCartItem.Id = cartItemId;

            return CreatedAtRoute("GetCartItemById", new { id = cartItemId }, newCartItem);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartItemDTO>> UpdateCartItem(long Id, CartItemDTO updatedCartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid cartItem data.");
            }

            if (!await oCartItem.IsExists(Id))
            {
                return NotFound($"CartItem with ID {Id} not found.");
            }

            updatedCartItem.Id = Id;

            if (!await oCartItem.Update(_mapper.Map<TbCartItem>(updatedCartItem)))
            {
                return BadRequest("Failed to update cartItem.");
            }

            return Ok(updatedCartItem);
        }        [HttpGet("All", Name = "GetAllCartItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetAllCartItems(int pageNumber = 1, int pageSize = 50)
        {
            var cartItemsList = await oCartItem.GetAll(pageNumber, pageSize);
            if (cartItemsList.Count == 0)
            {
                return NotFound("No CartItems Found!");
            }
            return Ok(_mapper.Map<IEnumerable<CartItemDTO>>(cartItemsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsCartItemExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsCartItemExists(long Id)
        {
            bool exists = await oCartItem.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "CartItem Not Found!" });
            }
            return Ok(new { Message = "CartItem Exists" });
        }

        [HttpGet("Count", Name = "GetCartItemsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetCartItemsCount()
        {
            return Ok(await oCartItem.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCartItem(long Id)
        {        
            if (await oCartItem.Delete(Id))
            {
                return Ok($"CartItem with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"CartItem with ID {Id} not found. No rows deleted!");
            }
        }

    }
}