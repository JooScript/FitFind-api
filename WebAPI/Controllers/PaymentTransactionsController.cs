using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/PaymentTransactions")]
    [ApiController]
    public class PaymentTransactionsController : ControllerBase
    {        IPaymentTransaction oPaymentTransaction;
        private readonly IMapper _mapper;
        public PaymentTransactionsController(IPaymentTransaction paymentTransaction, IMapper mapper)
        {
            oPaymentTransaction = paymentTransaction;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetPaymentTransactionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentTransactionDTO>> GetPaymentTransactionById(long Id)
        {
            TbPaymentTransaction paymentTransaction = await oPaymentTransaction.GetById(Id);

            if (paymentTransaction == null)
            {
                return NotFound($"PaymentTransaction with ID {Id} not found.");
            }

            return Ok(_mapper.Map<PaymentTransactionDTO>(paymentTransaction));
        }        [HttpPost(Name = "AddPaymentTransaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentTransactionDTO>> AddPaymentTransaction(PaymentTransactionDTO newPaymentTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid paymentTransaction data.");
            }

            long paymentTransactionId = await oPaymentTransaction.Add(_mapper.Map<TbPaymentTransaction>(newPaymentTransaction));

            if (paymentTransactionId <= 0)
            {
                return BadRequest("Failed to add paymentTransaction.");
            }

            newPaymentTransaction.Id = paymentTransactionId;

            return CreatedAtRoute("GetPaymentTransactionById", new { id = paymentTransactionId }, newPaymentTransaction);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdatePaymentTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentTransactionDTO>> UpdatePaymentTransaction(long Id, PaymentTransactionDTO updatedPaymentTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid paymentTransaction data.");
            }

            if (!await oPaymentTransaction.IsExists(Id))
            {
                return NotFound($"PaymentTransaction with ID {Id} not found.");
            }

            updatedPaymentTransaction.Id = Id;

            if (!await oPaymentTransaction.Update(_mapper.Map<TbPaymentTransaction>(updatedPaymentTransaction)))
            {
                return BadRequest("Failed to update paymentTransaction.");
            }

            return Ok(updatedPaymentTransaction);
        }        [HttpGet("All", Name = "GetAllPaymentTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PaymentTransactionDTO>>> GetAllPaymentTransactions(int pageNumber = 1, int pageSize = 50)
        {
            var paymentTransactionsList = await oPaymentTransaction.GetAll(pageNumber, pageSize);
            if (paymentTransactionsList.Count == 0)
            {
                return NotFound("No PaymentTransactions Found!");
            }
            return Ok(_mapper.Map<IEnumerable<PaymentTransactionDTO>>(paymentTransactionsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsPaymentTransactionExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsPaymentTransactionExists(long Id)
        {
            bool exists = await oPaymentTransaction.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "PaymentTransaction Not Found!" });
            }
            return Ok(new { Message = "PaymentTransaction Exists" });
        }

        [HttpGet("Count", Name = "GetPaymentTransactionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetPaymentTransactionsCount()
        {
            return Ok(await oPaymentTransaction.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeletePaymentTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePaymentTransaction(long Id)
        {        
            if (await oPaymentTransaction.Delete(Id))
            {
                return Ok($"PaymentTransaction with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"PaymentTransaction with ID {Id} not found. No rows deleted!");
            }
        }

    }
}