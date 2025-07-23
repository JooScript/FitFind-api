using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/ShipmentItemMappings")]
    [ApiController]
    public class ShipmentItemMappingsController : ControllerBase
    {        IShipmentItemMapping oShipmentItemMapping;
        private readonly IMapper _mapper;
        public ShipmentItemMappingsController(IShipmentItemMapping shipmentItemMapping, IMapper mapper)
        {
            oShipmentItemMapping = shipmentItemMapping;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetShipmentItemMappingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShipmentItemMappingDTO>> GetShipmentItemMappingById(long Id)
        {
            TbShipmentItemMapping shipmentItemMapping = await oShipmentItemMapping.GetById(Id);

            if (shipmentItemMapping == null)
            {
                return NotFound($"ShipmentItemMapping with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ShipmentItemMappingDTO>(shipmentItemMapping));
        }        [HttpPost(Name = "AddShipmentItemMapping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShipmentItemMappingDTO>> AddShipmentItemMapping(ShipmentItemMappingDTO newShipmentItemMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid shipmentItemMapping data.");
            }

            long shipmentItemMappingId = await oShipmentItemMapping.Add(_mapper.Map<TbShipmentItemMapping>(newShipmentItemMapping));

            if (shipmentItemMappingId <= 0)
            {
                return BadRequest("Failed to add shipmentItemMapping.");
            }

            newShipmentItemMapping.Id = shipmentItemMappingId;

            return CreatedAtRoute("GetShipmentItemMappingById", new { id = shipmentItemMappingId }, newShipmentItemMapping);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateShipmentItemMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShipmentItemMappingDTO>> UpdateShipmentItemMapping(long Id, ShipmentItemMappingDTO updatedShipmentItemMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid shipmentItemMapping data.");
            }

            if (!await oShipmentItemMapping.IsExists(Id))
            {
                return NotFound($"ShipmentItemMapping with ID {Id} not found.");
            }

            updatedShipmentItemMapping.Id = Id;

            if (!await oShipmentItemMapping.Update(_mapper.Map<TbShipmentItemMapping>(updatedShipmentItemMapping)))
            {
                return BadRequest("Failed to update shipmentItemMapping.");
            }

            return Ok(updatedShipmentItemMapping);
        }        [HttpGet("All", Name = "GetAllShipmentItemMappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ShipmentItemMappingDTO>>> GetAllShipmentItemMappings(int pageNumber = 1, int pageSize = 50)
        {
            var shipmentItemMappingsList = await oShipmentItemMapping.GetAll(pageNumber, pageSize);
            if (shipmentItemMappingsList.Count == 0)
            {
                return NotFound("No ShipmentItemMappings Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ShipmentItemMappingDTO>>(shipmentItemMappingsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsShipmentItemMappingExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsShipmentItemMappingExists(long Id)
        {
            bool exists = await oShipmentItemMapping.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "ShipmentItemMapping Not Found!" });
            }
            return Ok(new { Message = "ShipmentItemMapping Exists" });
        }

        [HttpGet("Count", Name = "GetShipmentItemMappingsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetShipmentItemMappingsCount()
        {
            return Ok(await oShipmentItemMapping.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteShipmentItemMapping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteShipmentItemMapping(long Id)
        {        
            if (await oShipmentItemMapping.Delete(Id))
            {
                return Ok($"ShipmentItemMapping with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"ShipmentItemMapping with ID {Id} not found. No rows deleted!");
            }
        }

    }
}