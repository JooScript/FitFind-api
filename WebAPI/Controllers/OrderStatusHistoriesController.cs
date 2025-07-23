using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/OrderStatusHistories")]
    [ApiController]
    public class OrderStatusHistoriesController : ControllerBase
    {        IOrderStatusHistory oOrderStatusHistory;
        private readonly IMapper _mapper;
        public OrderStatusHistoriesController(IOrderStatusHistory orderStatusHistory, IMapper mapper)
        {
            oOrderStatusHistory = orderStatusHistory;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetOrderStatusHistoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderStatusHistoryDTO>> GetOrderStatusHistoryById(long Id)
        {
            TbOrderStatusHistory orderStatusHistory = await oOrderStatusHistory.GetById(Id);

            if (orderStatusHistory == null)
            {
                return NotFound($"OrderStatusHistory with ID {Id} not found.");
            }

            return Ok(_mapper.Map<OrderStatusHistoryDTO>(orderStatusHistory));
        }        [HttpPost(Name = "AddOrderStatusHistory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderStatusHistoryDTO>> AddOrderStatusHistory(OrderStatusHistoryDTO newOrderStatusHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid orderStatusHistory data.");
            }

            long orderStatusHistoryId = await oOrderStatusHistory.Add(_mapper.Map<TbOrderStatusHistory>(newOrderStatusHistory));

            if (orderStatusHistoryId <= 0)
            {
                return BadRequest("Failed to add orderStatusHistory.");
            }

            newOrderStatusHistory.Id = orderStatusHistoryId;

            return CreatedAtRoute("GetOrderStatusHistoryById", new { id = orderStatusHistoryId }, newOrderStatusHistory);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateOrderStatusHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderStatusHistoryDTO>> UpdateOrderStatusHistory(long Id, OrderStatusHistoryDTO updatedOrderStatusHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid orderStatusHistory data.");
            }

            if (!await oOrderStatusHistory.IsExists(Id))
            {
                return NotFound($"OrderStatusHistory with ID {Id} not found.");
            }

            updatedOrderStatusHistory.Id = Id;

            if (!await oOrderStatusHistory.Update(_mapper.Map<TbOrderStatusHistory>(updatedOrderStatusHistory)))
            {
                return BadRequest("Failed to update orderStatusHistory.");
            }

            return Ok(updatedOrderStatusHistory);
        }        [HttpGet("All", Name = "GetAllOrderStatusHistories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<OrderStatusHistoryDTO>>> GetAllOrderStatusHistories(int pageNumber = 1, int pageSize = 50)
        {
            var orderStatusHistoriesList = await oOrderStatusHistory.GetAll(pageNumber, pageSize);
            if (orderStatusHistoriesList.Count == 0)
            {
                return NotFound("No OrderStatusHistories Found!");
            }
            return Ok(_mapper.Map<IEnumerable<OrderStatusHistoryDTO>>(orderStatusHistoriesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsOrderStatusHistoryExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsOrderStatusHistoryExists(long Id)
        {
            bool exists = await oOrderStatusHistory.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "OrderStatusHistory Not Found!" });
            }
            return Ok(new { Message = "OrderStatusHistory Exists" });
        }

        [HttpGet("Count", Name = "GetOrderStatusHistoriesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetOrderStatusHistoriesCount()
        {
            return Ok(await oOrderStatusHistory.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteOrderStatusHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderStatusHistory(long Id)
        {        
            if (await oOrderStatusHistory.Delete(Id))
            {
                return Ok($"OrderStatusHistory with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"OrderStatusHistory with ID {Id} not found. No rows deleted!");
            }
        }

    }
}