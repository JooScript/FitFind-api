using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {        IReview oReview;
        private readonly IMapper _mapper;
        public ReviewsController(IReview review, IMapper mapper)
        {
            oReview = review;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetReviewById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(long Id)
        {
            TbReview review = await oReview.GetById(Id);

            if (review == null)
            {
                return NotFound($"Review with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ReviewDTO>(review));
        }        [HttpPost(Name = "AddReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReviewDTO>> AddReview(ReviewDTO newReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid review data.");
            }

            long reviewId = await oReview.Add(_mapper.Map<TbReview>(newReview));

            if (reviewId <= 0)
            {
                return BadRequest("Failed to add review.");
            }

            newReview.Id = reviewId;

            return CreatedAtRoute("GetReviewById", new { id = reviewId }, newReview);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> UpdateReview(long Id, ReviewDTO updatedReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid review data.");
            }

            if (!await oReview.IsExists(Id))
            {
                return NotFound($"Review with ID {Id} not found.");
            }

            updatedReview.Id = Id;

            if (!await oReview.Update(_mapper.Map<TbReview>(updatedReview)))
            {
                return BadRequest("Failed to update review.");
            }

            return Ok(updatedReview);
        }        [HttpGet("All", Name = "GetAllReviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviews(int pageNumber = 1, int pageSize = 50)
        {
            var reviewsList = await oReview.GetAll(pageNumber, pageSize);
            if (reviewsList.Count == 0)
            {
                return NotFound("No Reviews Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ReviewDTO>>(reviewsList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsReviewExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsReviewExists(long Id)
        {
            bool exists = await oReview.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Review Not Found!" });
            }
            return Ok(new { Message = "Review Exists" });
        }

        [HttpGet("Count", Name = "GetReviewsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetReviewsCount()
        {
            return Ok(await oReview.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteReview(long Id)
        {        
            if (await oReview.Delete(Id))
            {
                return Ok($"Review with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Review with ID {Id} not found. No rows deleted!");
            }
        }

    }
}