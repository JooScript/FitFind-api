using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/OrderItems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {        IOrderItem oOrderItem;
        private readonly IMapper _mapper;
        public OrderItemsController(IOrderItem orderItem, IMapper mapper)
        {
            oOrderItem = orderItem;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetOrderItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItemById(long Id)
        {
            TbOrderItem orderItem = await oOrderItem.GetById(Id);

            if (orderItem == null)
            {
                return NotFound($"OrderItem with ID {Id} not found.");
            }

            return Ok(_mapper.Map<OrderItemDTO>(orderItem));
        }        [HttpPost(Name = "AddOrderItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderItemDTO>> AddOrderItem(OrderItemDTO newOrderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid orderItem data.");
            }

            long orderItemId = await oOrderItem.Add(_mapper.Map<TbOrderItem>(newOrderItem));

            if (orderItemId <= 0)
            {
                return BadRequest("Failed to add orderItem.");
            }

            newOrderItem.Id = orderItemId;

            return CreatedAtRoute("GetOrderItemById", new { id = orderItemId }, newOrderItem);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateOrderItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderItemDTO>> UpdateOrderItem(long Id, OrderItemDTO updatedOrderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid orderItem data.");
            }

            if (!await oOrderItem.IsExists(Id))
            {
                return NotFound($"OrderItem with ID {Id} not found.");
            }

            updatedOrderItem.Id = Id;

            if (!await oOrderItem.Update(_mapper.Map<TbOrderItem>(updatedOrderItem)))
            {
                return BadRequest("Failed to update orderItem.");
            }

            return Ok(updatedOrderItem);
        }        [HttpGet("All", Name = "GetAllOrderItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<OrderItemDTO>>> GetAllOrderItems(int pageNumber = 1, int pageSize = 50)
        {
            var orderItemsList = await oOrderItem.GetAll(pageNumber, pageSize);
            if (orderItemsList.Count == 0)
            {
                return NotFound("No OrderItems Found!");
            }
            return Ok(_mapper.Map<IEnumerable<OrderItemDTO>>(orderItemsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsOrderItemExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsOrderItemExists(long Id)
        {
            bool exists = await oOrderItem.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "OrderItem Not Found!" });
            }
            return Ok(new { Message = "OrderItem Exists" });
        }

        [HttpGet("Count", Name = "GetOrderItemsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetOrderItemsCount()
        {
            return Ok(await oOrderItem.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteOrderItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderItem(long Id)
        {        
            if (await oOrderItem.Delete(Id))
            {
                return Ok($"OrderItem with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"OrderItem with ID {Id} not found. No rows deleted!");
            }
        }

    }
}