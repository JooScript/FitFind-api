using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {        IInvoice oInvoice;
        private readonly IMapper _mapper;
        public InvoicesController(IInvoice invoice, IMapper mapper)
        {
            oInvoice = invoice;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetInvoiceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceDTO>> GetInvoiceById(long Id)
        {
            TbInvoice invoice = await oInvoice.GetById(Id);

            if (invoice == null)
            {
                return NotFound($"Invoice with ID {Id} not found.");
            }

            return Ok(_mapper.Map<InvoiceDTO>(invoice));
        }        [HttpPost(Name = "AddInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InvoiceDTO>> AddInvoice(InvoiceDTO newInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid invoice data.");
            }

            long invoiceId = await oInvoice.Add(_mapper.Map<TbInvoice>(newInvoice));

            if (invoiceId <= 0)
            {
                return BadRequest("Failed to add invoice.");
            }

            newInvoice.Id = invoiceId;

            return CreatedAtRoute("GetInvoiceById", new { id = invoiceId }, newInvoice);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceDTO>> UpdateInvoice(long Id, InvoiceDTO updatedInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid invoice data.");
            }

            if (!await oInvoice.IsExists(Id))
            {
                return NotFound($"Invoice with ID {Id} not found.");
            }

            updatedInvoice.Id = Id;

            if (!await oInvoice.Update(_mapper.Map<TbInvoice>(updatedInvoice)))
            {
                return BadRequest("Failed to update invoice.");
            }

            return Ok(updatedInvoice);
        }        [HttpGet("All", Name = "GetAllInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAllInvoices(int pageNumber = 1, int pageSize = 50)
        {
            var invoicesList = await oInvoice.GetAll(pageNumber, pageSize);
            if (invoicesList.Count == 0)
            {
                return NotFound("No Invoices Found!");
            }
            return Ok(_mapper.Map<IEnumerable<InvoiceDTO>>(invoicesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsInvoiceExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsInvoiceExists(long Id)
        {
            bool exists = await oInvoice.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Invoice Not Found!" });
            }
            return Ok(new { Message = "Invoice Exists" });
        }

        [HttpGet("Count", Name = "GetInvoicesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetInvoicesCount()
        {
            return Ok(await oInvoice.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteInvoice(long Id)
        {        
            if (await oInvoice.Delete(Id))
            {
                return Ok($"Invoice with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Invoice with ID {Id} not found. No rows deleted!");
            }
        }

    }
}