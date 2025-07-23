using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/InventoryTransactions")]
    [ApiController]
    public class InventoryTransactionsController : ControllerBase
    {        IInventoryTransaction oInventoryTransaction;
        private readonly IMapper _mapper;
        public InventoryTransactionsController(IInventoryTransaction inventoryTransaction, IMapper mapper)
        {
            oInventoryTransaction = inventoryTransaction;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetInventoryTransactionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventoryTransactionDTO>> GetInventoryTransactionById(long Id)
        {
            TbInventoryTransaction inventoryTransaction = await oInventoryTransaction.GetById(Id);

            if (inventoryTransaction == null)
            {
                return NotFound($"InventoryTransaction with ID {Id} not found.");
            }

            return Ok(_mapper.Map<InventoryTransactionDTO>(inventoryTransaction));
        }        [HttpPost(Name = "AddInventoryTransaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventoryTransactionDTO>> AddInventoryTransaction(InventoryTransactionDTO newInventoryTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inventoryTransaction data.");
            }

            long inventoryTransactionId = await oInventoryTransaction.Add(_mapper.Map<TbInventoryTransaction>(newInventoryTransaction));

            if (inventoryTransactionId <= 0)
            {
                return BadRequest("Failed to add inventoryTransaction.");
            }

            newInventoryTransaction.Id = inventoryTransactionId;

            return CreatedAtRoute("GetInventoryTransactionById", new { id = inventoryTransactionId }, newInventoryTransaction);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateInventoryTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventoryTransactionDTO>> UpdateInventoryTransaction(long Id, InventoryTransactionDTO updatedInventoryTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid inventoryTransaction data.");
            }

            if (!await oInventoryTransaction.IsExists(Id))
            {
                return NotFound($"InventoryTransaction with ID {Id} not found.");
            }

            updatedInventoryTransaction.Id = Id;

            if (!await oInventoryTransaction.Update(_mapper.Map<TbInventoryTransaction>(updatedInventoryTransaction)))
            {
                return BadRequest("Failed to update inventoryTransaction.");
            }

            return Ok(updatedInventoryTransaction);
        }        [HttpGet("All", Name = "GetAllInventoryTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<InventoryTransactionDTO>>> GetAllInventoryTransactions(int pageNumber = 1, int pageSize = 50)
        {
            var inventoryTransactionsList = await oInventoryTransaction.GetAll(pageNumber, pageSize);
            if (inventoryTransactionsList.Count == 0)
            {
                return NotFound("No InventoryTransactions Found!");
            }
            return Ok(_mapper.Map<IEnumerable<InventoryTransactionDTO>>(inventoryTransactionsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsInventoryTransactionExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsInventoryTransactionExists(long Id)
        {
            bool exists = await oInventoryTransaction.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "InventoryTransaction Not Found!" });
            }
            return Ok(new { Message = "InventoryTransaction Exists" });
        }

        [HttpGet("Count", Name = "GetInventoryTransactionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetInventoryTransactionsCount()
        {
            return Ok(await oInventoryTransaction.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteInventoryTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteInventoryTransaction(long Id)
        {        
            if (await oInventoryTransaction.Delete(Id))
            {
                return Ok($"InventoryTransaction with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"InventoryTransaction with ID {Id} not found. No rows deleted!");
            }
        }

    }
}