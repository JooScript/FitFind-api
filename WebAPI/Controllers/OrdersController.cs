using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {        IOrder oOrder;
        private readonly IMapper _mapper;
        public OrdersController(IOrder order, IMapper mapper)
        {
            oOrder = order;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> GetOrderById(long Id)
        {
            TbOrder order = await oOrder.GetById(Id);

            if (order == null)
            {
                return NotFound($"Order with ID {Id} not found.");
            }

            return Ok(_mapper.Map<OrderDTO>(order));
        }        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDTO>> AddOrder(OrderDTO newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid order data.");
            }

            long orderId = await oOrder.Add(_mapper.Map<TbOrder>(newOrder));

            if (orderId <= 0)
            {
                return BadRequest("Failed to add order.");
            }

            newOrder.Id = orderId;

            return CreatedAtRoute("GetOrderById", new { id = orderId }, newOrder);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(long Id, OrderDTO updatedOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid order data.");
            }

            if (!await oOrder.IsExists(Id))
            {
                return NotFound($"Order with ID {Id} not found.");
            }

            updatedOrder.Id = Id;

            if (!await oOrder.Update(_mapper.Map<TbOrder>(updatedOrder)))
            {
                return BadRequest("Failed to update order.");
            }

            return Ok(updatedOrder);
        }        [HttpGet("All", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders(int pageNumber = 1, int pageSize = 50)
        {
            var ordersList = await oOrder.GetAll(pageNumber, pageSize);
            if (ordersList.Count == 0)
            {
                return NotFound("No Orders Found!");
            }
            return Ok(_mapper.Map<IEnumerable<OrderDTO>>(ordersList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsOrderExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsOrderExists(long Id)
        {
            bool exists = await oOrder.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Order Not Found!" });
            }
            return Ok(new { Message = "Order Exists" });
        }

        [HttpGet("Count", Name = "GetOrdersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetOrdersCount()
        {
            return Ok(await oOrder.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrder(long Id)
        {        
            if (await oOrder.Delete(Id))
            {
                return Ok($"Order with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Order with ID {Id} not found. No rows deleted!");
            }
        }

    }
}