using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {        IImage oImage;
        private readonly IMapper _mapper;
        public ImagesController(IImage image, IMapper mapper)
        {
            oImage = image;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetImageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ImageDTO>> GetImageById(long Id)
        {
            TbImage image = await oImage.GetById(Id);

            if (image == null)
            {
                return NotFound($"Image with ID {Id} not found.");
            }

            return Ok(_mapper.Map<ImageDTO>(image));
        }        [HttpPost(Name = "AddImage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ImageDTO>> AddImage(ImageDTO newImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid image data.");
            }

            long imageId = await oImage.Add(_mapper.Map<TbImage>(newImage));

            if (imageId <= 0)
            {
                return BadRequest("Failed to add image.");
            }

            newImage.Id = imageId;

            return CreatedAtRoute("GetImageById", new { id = imageId }, newImage);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ImageDTO>> UpdateImage(long Id, ImageDTO updatedImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid image data.");
            }

            if (!await oImage.IsExists(Id))
            {
                return NotFound($"Image with ID {Id} not found.");
            }

            updatedImage.Id = Id;

            if (!await oImage.Update(_mapper.Map<TbImage>(updatedImage)))
            {
                return BadRequest("Failed to update image.");
            }

            return Ok(updatedImage);
        }        [HttpGet("All", Name = "GetAllImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetAllImages(int pageNumber = 1, int pageSize = 50)
        {
            var imagesList = await oImage.GetAll(pageNumber, pageSize);
            if (imagesList.Count == 0)
            {
                return NotFound("No Images Found!");
            }
            return Ok(_mapper.Map<IEnumerable<ImageDTO>>(imagesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsImageExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsImageExists(long Id)
        {
            bool exists = await oImage.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Image Not Found!" });
            }
            return Ok(new { Message = "Image Exists" });
        }

        [HttpGet("Count", Name = "GetImagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetImagesCount()
        {
            return Ok(await oImage.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteImage(long Id)
        {        
            if (await oImage.Delete(Id))
            {
                return Ok($"Image with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Image with ID {Id} not found. No rows deleted!");
            }
        }

    }
}