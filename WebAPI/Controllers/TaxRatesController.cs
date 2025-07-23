using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/TaxRates")]
    [ApiController]
    public class TaxRatesController : ControllerBase
    {        ITaxRate oTaxRate;
        private readonly IMapper _mapper;
        public TaxRatesController(ITaxRate taxRate, IMapper mapper)
        {
            oTaxRate = taxRate;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetTaxRateById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaxRateDTO>> GetTaxRateById(long Id)
        {
            TbTaxRate taxRate = await oTaxRate.GetById(Id);

            if (taxRate == null)
            {
                return NotFound($"TaxRate with ID {Id} not found.");
            }

            return Ok(_mapper.Map<TaxRateDTO>(taxRate));
        }        [HttpPost(Name = "AddTaxRate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaxRateDTO>> AddTaxRate(TaxRateDTO newTaxRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid taxRate data.");
            }

            long taxRateId = await oTaxRate.Add(_mapper.Map<TbTaxRate>(newTaxRate));

            if (taxRateId <= 0)
            {
                return BadRequest("Failed to add taxRate.");
            }

            newTaxRate.Id = taxRateId;

            return CreatedAtRoute("GetTaxRateById", new { id = taxRateId }, newTaxRate);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateTaxRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaxRateDTO>> UpdateTaxRate(long Id, TaxRateDTO updatedTaxRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid taxRate data.");
            }

            if (!await oTaxRate.IsExists(Id))
            {
                return NotFound($"TaxRate with ID {Id} not found.");
            }

            updatedTaxRate.Id = Id;

            if (!await oTaxRate.Update(_mapper.Map<TbTaxRate>(updatedTaxRate)))
            {
                return BadRequest("Failed to update taxRate.");
            }

            return Ok(updatedTaxRate);
        }        [HttpGet("All", Name = "GetAllTaxRates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TaxRateDTO>>> GetAllTaxRates(int pageNumber = 1, int pageSize = 50)
        {
            var taxRatesList = await oTaxRate.GetAll(pageNumber, pageSize);
            if (taxRatesList.Count == 0)
            {
                return NotFound("No TaxRates Found!");
            }
            return Ok(_mapper.Map<IEnumerable<TaxRateDTO>>(taxRatesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsTaxRateExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsTaxRateExists(long Id)
        {
            bool exists = await oTaxRate.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "TaxRate Not Found!" });
            }
            return Ok(new { Message = "TaxRate Exists" });
        }

        [HttpGet("Count", Name = "GetTaxRatesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetTaxRatesCount()
        {
            return Ok(await oTaxRate.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteTaxRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTaxRate(long Id)
        {        
            if (await oTaxRate.Delete(Id))
            {
                return Ok($"TaxRate with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"TaxRate with ID {Id} not found. No rows deleted!");
            }
        }

    }
}