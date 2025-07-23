using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {        ISubscription oSubscription;
        private readonly IMapper _mapper;
        public SubscriptionsController(ISubscription subscription, IMapper mapper)
        {
            oSubscription = subscription;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetSubscriptionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionDTO>> GetSubscriptionById(long Id)
        {
            TbSubscription subscription = await oSubscription.GetById(Id);

            if (subscription == null)
            {
                return NotFound($"Subscription with ID {Id} not found.");
            }

            return Ok(_mapper.Map<SubscriptionDTO>(subscription));
        }        [HttpPost(Name = "AddSubscription")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubscriptionDTO>> AddSubscription(SubscriptionDTO newSubscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid subscription data.");
            }

            long subscriptionId = await oSubscription.Add(_mapper.Map<TbSubscription>(newSubscription));

            if (subscriptionId <= 0)
            {
                return BadRequest("Failed to add subscription.");
            }

            newSubscription.Id = subscriptionId;

            return CreatedAtRoute("GetSubscriptionById", new { id = subscriptionId }, newSubscription);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateSubscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionDTO>> UpdateSubscription(long Id, SubscriptionDTO updatedSubscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid subscription data.");
            }

            if (!await oSubscription.IsExists(Id))
            {
                return NotFound($"Subscription with ID {Id} not found.");
            }

            updatedSubscription.Id = Id;

            if (!await oSubscription.Update(_mapper.Map<TbSubscription>(updatedSubscription)))
            {
                return BadRequest("Failed to update subscription.");
            }

            return Ok(updatedSubscription);
        }        [HttpGet("All", Name = "GetAllSubscriptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SubscriptionDTO>>> GetAllSubscriptions(int pageNumber = 1, int pageSize = 50)
        {
            var subscriptionsList = await oSubscription.GetAll(pageNumber, pageSize);
            if (subscriptionsList.Count == 0)
            {
                return NotFound("No Subscriptions Found!");
            }
            return Ok(_mapper.Map<IEnumerable<SubscriptionDTO>>(subscriptionsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsSubscriptionExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsSubscriptionExists(long Id)
        {
            bool exists = await oSubscription.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Subscription Not Found!" });
            }
            return Ok(new { Message = "Subscription Exists" });
        }

        [HttpGet("Count", Name = "GetSubscriptionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetSubscriptionsCount()
        {
            return Ok(await oSubscription.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteSubscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSubscription(long Id)
        {        
            if (await oSubscription.Delete(Id))
            {
                return Ok($"Subscription with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Subscription with ID {Id} not found. No rows deleted!");
            }
        }

    }
}