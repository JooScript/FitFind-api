using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Methods")]
    [ApiController]
    public class MethodsController : ControllerBase
    {        IMethod oMethod;
        private readonly IMapper _mapper;
        public MethodsController(IMethod method, IMapper mapper)
        {
            oMethod = method;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetMethodById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodDTO>> GetMethodById(long Id)
        {
            TbMethod method = await oMethod.GetById(Id);

            if (method == null)
            {
                return NotFound($"Method with ID {Id} not found.");
            }

            return Ok(_mapper.Map<MethodDTO>(method));
        }        [HttpPost(Name = "AddMethod")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MethodDTO>> AddMethod(MethodDTO newMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid method data.");
            }

            long methodId = await oMethod.Add(_mapper.Map<TbMethod>(newMethod));

            if (methodId <= 0)
            {
                return BadRequest("Failed to add method.");
            }

            newMethod.Id = methodId;

            return CreatedAtRoute("GetMethodById", new { id = methodId }, newMethod);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodDTO>> UpdateMethod(long Id, MethodDTO updatedMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid method data.");
            }

            if (!await oMethod.IsExists(Id))
            {
                return NotFound($"Method with ID {Id} not found.");
            }

            updatedMethod.Id = Id;

            if (!await oMethod.Update(_mapper.Map<TbMethod>(updatedMethod)))
            {
                return BadRequest("Failed to update method.");
            }

            return Ok(updatedMethod);
        }        [HttpGet("All", Name = "GetAllMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MethodDTO>>> GetAllMethods(int pageNumber = 1, int pageSize = 50)
        {
            var methodsList = await oMethod.GetAll(pageNumber, pageSize);
            if (methodsList.Count == 0)
            {
                return NotFound("No Methods Found!");
            }
            return Ok(_mapper.Map<IEnumerable<MethodDTO>>(methodsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsMethodExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsMethodExists(long Id)
        {
            bool exists = await oMethod.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Method Not Found!" });
            }
            return Ok(new { Message = "Method Exists" });
        }

        [HttpGet("Count", Name = "GetMethodsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetMethodsCount()
        {
            return Ok(await oMethod.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMethod(long Id)
        {        
            if (await oMethod.Delete(Id))
            {
                return Ok($"Method with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Method with ID {Id} not found. No rows deleted!");
            }
        }

    }
}