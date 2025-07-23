using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/UserActivities")]
    [ApiController]
    public class UserActivitiesController : ControllerBase
    {        IUserActivity oUserActivity;
        private readonly IMapper _mapper;
        public UserActivitiesController(IUserActivity userActivity, IMapper mapper)
        {
            oUserActivity = userActivity;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetUserActivityById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserActivityDTO>> GetUserActivityById(long Id)
        {
            TbUserActivity userActivity = await oUserActivity.GetById(Id);

            if (userActivity == null)
            {
                return NotFound($"UserActivity with ID {Id} not found.");
            }

            return Ok(_mapper.Map<UserActivityDTO>(userActivity));
        }        [HttpPost(Name = "AddUserActivity")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserActivityDTO>> AddUserActivity(UserActivityDTO newUserActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid userActivity data.");
            }

            long userActivityId = await oUserActivity.Add(_mapper.Map<TbUserActivity>(newUserActivity));

            if (userActivityId <= 0)
            {
                return BadRequest("Failed to add userActivity.");
            }

            newUserActivity.Id = userActivityId;

            return CreatedAtRoute("GetUserActivityById", new { id = userActivityId }, newUserActivity);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateUserActivity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserActivityDTO>> UpdateUserActivity(long Id, UserActivityDTO updatedUserActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid userActivity data.");
            }

            if (!await oUserActivity.IsExists(Id))
            {
                return NotFound($"UserActivity with ID {Id} not found.");
            }

            updatedUserActivity.Id = Id;

            if (!await oUserActivity.Update(_mapper.Map<TbUserActivity>(updatedUserActivity)))
            {
                return BadRequest("Failed to update userActivity.");
            }

            return Ok(updatedUserActivity);
        }        [HttpGet("All", Name = "GetAllUserActivities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserActivityDTO>>> GetAllUserActivities(int pageNumber = 1, int pageSize = 50)
        {
            var userActivitiesList = await oUserActivity.GetAll(pageNumber, pageSize);
            if (userActivitiesList.Count == 0)
            {
                return NotFound("No UserActivities Found!");
            }
            return Ok(_mapper.Map<IEnumerable<UserActivityDTO>>(userActivitiesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsUserActivityExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsUserActivityExists(long Id)
        {
            bool exists = await oUserActivity.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "UserActivity Not Found!" });
            }
            return Ok(new { Message = "UserActivity Exists" });
        }

        [HttpGet("Count", Name = "GetUserActivitiesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetUserActivitiesCount()
        {
            return Ok(await oUserActivity.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteUserActivity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUserActivity(long Id)
        {        
            if (await oUserActivity.Delete(Id))
            {
                return Ok($"UserActivity with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"UserActivity with ID {Id} not found. No rows deleted!");
            }
        }

    }
}