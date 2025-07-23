using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {        IAddress oAddress;
        private readonly IMapper _mapper;
        public AddressesController(IAddress address, IMapper mapper)
        {
            oAddress = address;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetAddressById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDTO>> GetAddressById(long Id)
        {
            TbAddress address = await oAddress.GetById(Id);

            if (address == null)
            {
                return NotFound($"Address with ID {Id} not found.");
            }

            return Ok(_mapper.Map<AddressDTO>(address));
        }        [HttpPost(Name = "AddAddress")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressDTO>> AddAddress(AddressDTO newAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid address data.");
            }

            long addressId = await oAddress.Add(_mapper.Map<TbAddress>(newAddress));

            if (addressId <= 0)
            {
                return BadRequest("Failed to add address.");
            }

            newAddress.Id = addressId;

            return CreatedAtRoute("GetAddressById", new { id = addressId }, newAddress);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(long Id, AddressDTO updatedAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid address data.");
            }

            if (!await oAddress.IsExists(Id))
            {
                return NotFound($"Address with ID {Id} not found.");
            }

            updatedAddress.Id = Id;

            if (!await oAddress.Update(_mapper.Map<TbAddress>(updatedAddress)))
            {
                return BadRequest("Failed to update address.");
            }

            return Ok(updatedAddress);
        }        [HttpGet("All", Name = "GetAllAddresses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAddresses(int pageNumber = 1, int pageSize = 50)
        {
            var addressesList = await oAddress.GetAll(pageNumber, pageSize);
            if (addressesList.Count == 0)
            {
                return NotFound("No Addresses Found!");
            }
            return Ok(_mapper.Map<IEnumerable<AddressDTO>>(addressesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsAddressExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsAddressExists(long Id)
        {
            bool exists = await oAddress.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Address Not Found!" });
            }
            return Ok(new { Message = "Address Exists" });
        }

        [HttpGet("Count", Name = "GetAddressesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetAddressesCount()
        {
            return Ok(await oAddress.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAddress(long Id)
        {        
            if (await oAddress.Delete(Id))
            {
                return Ok($"Address with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Address with ID {Id} not found. No rows deleted!");
            }
        }

    }
}