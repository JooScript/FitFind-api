using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {        IPayment oPayment;
        private readonly IMapper _mapper;
        public PaymentsController(IPayment payment, IMapper mapper)
        {
            oPayment = payment;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetPaymentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDTO>> GetPaymentById(long Id)
        {
            TbPayment payment = await oPayment.GetById(Id);

            if (payment == null)
            {
                return NotFound($"Payment with ID {Id} not found.");
            }

            return Ok(_mapper.Map<PaymentDTO>(payment));
        }        [HttpPost(Name = "AddPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentDTO>> AddPayment(PaymentDTO newPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payment data.");
            }

            long paymentId = await oPayment.Add(_mapper.Map<TbPayment>(newPayment));

            if (paymentId <= 0)
            {
                return BadRequest("Failed to add payment.");
            }

            newPayment.Id = paymentId;

            return CreatedAtRoute("GetPaymentById", new { id = paymentId }, newPayment);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDTO>> UpdatePayment(long Id, PaymentDTO updatedPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payment data.");
            }

            if (!await oPayment.IsExists(Id))
            {
                return NotFound($"Payment with ID {Id} not found.");
            }

            updatedPayment.Id = Id;

            if (!await oPayment.Update(_mapper.Map<TbPayment>(updatedPayment)))
            {
                return BadRequest("Failed to update payment.");
            }

            return Ok(updatedPayment);
        }        [HttpGet("All", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetAllPayments(int pageNumber = 1, int pageSize = 50)
        {
            var paymentsList = await oPayment.GetAll(pageNumber, pageSize);
            if (paymentsList.Count == 0)
            {
                return NotFound("No Payments Found!");
            }
            return Ok(_mapper.Map<IEnumerable<PaymentDTO>>(paymentsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsPaymentExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsPaymentExists(long Id)
        {
            bool exists = await oPayment.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Payment Not Found!" });
            }
            return Ok(new { Message = "Payment Exists" });
        }

        [HttpGet("Count", Name = "GetPaymentsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetPaymentsCount()
        {
            return Ok(await oPayment.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePayment(long Id)
        {        
            if (await oPayment.Delete(Id))
            {
                return Ok($"Payment with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Payment with ID {Id} not found. No rows deleted!");
            }
        }

    }
}