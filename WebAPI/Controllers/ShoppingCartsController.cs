using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/ShoppingCarts")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {        IShoppingCart oShoppingCart;
        private readonly IMapper _mapper;
        public ShoppingCartsController(IShoppingCart shoppingCart, IMapper mapper)
        {
            oShoppingCart = shoppingCart;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetShoppingCartById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShoppingCartDTO>> GetShoppingCartById(long Id)
        {
            TbShoppingCart shoppingCart = await oShoppingCart.GetById(Id);

            if (shoppingCart == null)
            {
                return NotFound($"ShoppingCart with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ShoppingCartDTO>(shoppingCart));
        }        [HttpPost(Name = "AddShoppingCart")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShoppingCartDTO>> AddShoppingCart(ShoppingCartDTO newShoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid shoppingCart data.");
            }

            long shoppingCartId = await oShoppingCart.Add(_mapper.Map<TbShoppingCart>(newShoppingCart));

            if (shoppingCartId <= 0)
            {
                return BadRequest("Failed to add shoppingCart.");
            }

            newShoppingCart.Id = shoppingCartId;

            return CreatedAtRoute("GetShoppingCartById", new { id = shoppingCartId }, newShoppingCart);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateShoppingCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShoppingCartDTO>> UpdateShoppingCart(long Id, ShoppingCartDTO updatedShoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid shoppingCart data.");
            }

            if (!await oShoppingCart.IsExists(Id))
            {
                return NotFound($"ShoppingCart with ID {Id} not found.");
            }

            updatedShoppingCart.Id = Id;

            if (!await oShoppingCart.Update(_mapper.Map<TbShoppingCart>(updatedShoppingCart)))
            {
                return BadRequest("Failed to update shoppingCart.");
            }

            return Ok(updatedShoppingCart);
        }        [HttpGet("All", Name = "GetAllShoppingCarts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ShoppingCartDTO>>> GetAllShoppingCarts(int pageNumber = 1, int pageSize = 50)
        {
            var shoppingCartsList = await oShoppingCart.GetAll(pageNumber, pageSize);
            if (shoppingCartsList.Count == 0)
            {
                return NotFound("No ShoppingCarts Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ShoppingCartDTO>>(shoppingCartsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsShoppingCartExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsShoppingCartExists(long Id)
        {
            bool exists = await oShoppingCart.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "ShoppingCart Not Found!" });
            }
            return Ok(new { Message = "ShoppingCart Exists" });
        }

        [HttpGet("Count", Name = "GetShoppingCartsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetShoppingCartsCount()
        {
            return Ok(await oShoppingCart.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteShoppingCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteShoppingCart(long Id)
        {        
            if (await oShoppingCart.Delete(Id))
            {
                return Ok($"ShoppingCart with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"ShoppingCart with ID {Id} not found. No rows deleted!");
            }
        }

    }
}