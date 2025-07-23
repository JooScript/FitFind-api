using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {        IShipment oShipment;
        private readonly IMapper _mapper;
        public ShipmentsController(IShipment shipment, IMapper mapper)
        {
            oShipment = shipment;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetShipmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShipmentDTO>> GetShipmentById(long Id)
        {
            TbShipment shipment = await oShipment.GetById(Id);

            if (shipment == null)
            {
                return NotFound($"Shipment with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ShipmentDTO>(shipment));
        }        [HttpPost(Name = "AddShipment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShipmentDTO>> AddShipment(ShipmentDTO newShipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid shipment data.");
            }

            long shipmentId = await oShipment.Add(_mapper.Map<TbShipment>(newShipment));

            if (shipmentId <= 0)
            {
                return BadRequest("Failed to add shipment.");
            }

            newShipment.Id = shipmentId;

            return CreatedAtRoute("GetShipmentById", new { id = shipmentId }, newShipment);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateShipment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShipmentDTO>> UpdateShipment(long Id, ShipmentDTO updatedShipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid shipment data.");
            }

            if (!await oShipment.IsExists(Id))
            {
                return NotFound($"Shipment with ID {Id} not found.");
            }

            updatedShipment.Id = Id;

            if (!await oShipment.Update(_mapper.Map<TbShipment>(updatedShipment)))
            {
                return BadRequest("Failed to update shipment.");
            }

            return Ok(updatedShipment);
        }        [HttpGet("All", Name = "GetAllShipments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ShipmentDTO>>> GetAllShipments(int pageNumber = 1, int pageSize = 50)
        {
            var shipmentsList = await oShipment.GetAll(pageNumber, pageSize);
            if (shipmentsList.Count == 0)
            {
                return NotFound("No Shipments Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ShipmentDTO>>(shipmentsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsShipmentExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsShipmentExists(long Id)
        {
            bool exists = await oShipment.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Shipment Not Found!" });
            }
            return Ok(new { Message = "Shipment Exists" });
        }

        [HttpGet("Count", Name = "GetShipmentsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetShipmentsCount()
        {
            return Ok(await oShipment.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteShipment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteShipment(long Id)
        {        
            if (await oShipment.Delete(Id))
            {
                return Ok($"Shipment with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Shipment with ID {Id} not found. No rows deleted!");
            }
        }

    }
}