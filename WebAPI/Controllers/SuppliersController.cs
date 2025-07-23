using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {        ISupplier oSupplier;
        private readonly IMapper _mapper;
        public SuppliersController(ISupplier supplier, IMapper mapper)
        {
            oSupplier = supplier;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetSupplierById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SupplierDTO>> GetSupplierById(long Id)
        {
            TbSupplier supplier = await oSupplier.GetById(Id);

            if (supplier == null)
            {
                return NotFound($"Supplier with ID {Id} not found.");
            }

            return Ok(_mapper.Map<SupplierDTO>(supplier));
        }        [HttpPost(Name = "AddSupplier")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SupplierDTO>> AddSupplier(SupplierDTO newSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid supplier data.");
            }

            long supplierId = await oSupplier.Add(_mapper.Map<TbSupplier>(newSupplier));

            if (supplierId <= 0)
            {
                return BadRequest("Failed to add supplier.");
            }

            newSupplier.Id = supplierId;

            return CreatedAtRoute("GetSupplierById", new { id = supplierId }, newSupplier);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateSupplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SupplierDTO>> UpdateSupplier(long Id, SupplierDTO updatedSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid supplier data.");
            }

            if (!await oSupplier.IsExists(Id))
            {
                return NotFound($"Supplier with ID {Id} not found.");
            }

            updatedSupplier.Id = Id;

            if (!await oSupplier.Update(_mapper.Map<TbSupplier>(updatedSupplier)))
            {
                return BadRequest("Failed to update supplier.");
            }

            return Ok(updatedSupplier);
        }        [HttpGet("All", Name = "GetAllSuppliers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetAllSuppliers(int pageNumber = 1, int pageSize = 50)
        {
            var suppliersList = await oSupplier.GetAll(pageNumber, pageSize);
            if (suppliersList.Count == 0)
            {
                return NotFound("No Suppliers Found!");
            }
            return Ok(_mapper.Map<IEnumerable<SupplierDTO>>(suppliersList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsSupplierExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsSupplierExists(long Id)
        {
            bool exists = await oSupplier.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Supplier Not Found!" });
            }
            return Ok(new { Message = "Supplier Exists" });
        }

        [HttpGet("Count", Name = "GetSuppliersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetSuppliersCount()
        {
            return Ok(await oSupplier.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteSupplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSupplier(long Id)
        {        
            if (await oSupplier.Delete(Id))
            {
                return Ok($"Supplier with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Supplier with ID {Id} not found. No rows deleted!");
            }
        }

    }
}