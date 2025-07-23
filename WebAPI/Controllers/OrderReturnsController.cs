using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/OrderReturns")]
    [ApiController]
    public class OrderReturnsController : ControllerBase
    {        IOrderReturn oOrderReturn;
        private readonly IMapper _mapper;
        public OrderReturnsController(IOrderReturn orderReturn, IMapper mapper)
        {
            oOrderReturn = orderReturn;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetOrderReturnById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderReturnDTO>> GetOrderReturnById(long Id)
        {
            TbOrderReturn orderReturn = await oOrderReturn.GetById(Id);

            if (orderReturn == null)
            {
                return NotFound($"OrderReturn with ID {Id} not found.");
            }

            return Ok(_mapper.Map<OrderReturnDTO>(orderReturn));
        }        [HttpPost(Name = "AddOrderReturn")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderReturnDTO>> AddOrderReturn(OrderReturnDTO newOrderReturn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid orderReturn data.");
            }

            long orderReturnId = await oOrderReturn.Add(_mapper.Map<TbOrderReturn>(newOrderReturn));

            if (orderReturnId <= 0)
            {
                return BadRequest("Failed to add orderReturn.");
            }

            newOrderReturn.Id = orderReturnId;

            return CreatedAtRoute("GetOrderReturnById", new { id = orderReturnId }, newOrderReturn);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateOrderReturn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderReturnDTO>> UpdateOrderReturn(long Id, OrderReturnDTO updatedOrderReturn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid orderReturn data.");
            }

            if (!await oOrderReturn.IsExists(Id))
            {
                return NotFound($"OrderReturn with ID {Id} not found.");
            }

            updatedOrderReturn.Id = Id;

            if (!await oOrderReturn.Update(_mapper.Map<TbOrderReturn>(updatedOrderReturn)))
            {
                return BadRequest("Failed to update orderReturn.");
            }

            return Ok(updatedOrderReturn);
        }        [HttpGet("All", Name = "GetAllOrderReturns")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<OrderReturnDTO>>> GetAllOrderReturns(int pageNumber = 1, int pageSize = 50)
        {
            var orderReturnsList = await oOrderReturn.GetAll(pageNumber, pageSize);
            if (orderReturnsList.Count == 0)
            {
                return NotFound("No OrderReturns Found!");
            }
            return Ok(_mapper.Map<IEnumerable<OrderReturnDTO>>(orderReturnsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsOrderReturnExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsOrderReturnExists(long Id)
        {
            bool exists = await oOrderReturn.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "OrderReturn Not Found!" });
            }
            return Ok(new { Message = "OrderReturn Exists" });
        }

        [HttpGet("Count", Name = "GetOrderReturnsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetOrderReturnsCount()
        {
            return Ok(await oOrderReturn.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteOrderReturn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderReturn(long Id)
        {        
            if (await oOrderReturn.Delete(Id))
            {
                return Ok($"OrderReturn with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"OrderReturn with ID {Id} not found. No rows deleted!");
            }
        }

    }
}