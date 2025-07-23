using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {        ICategory oCategory;
        private readonly IMapper _mapper;
        public CategoriesController(ICategory category, IMapper mapper)
        {
            oCategory = category;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:long:min(1)}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(long Id)
        {
            TbCategory category = await oCategory.GetById(Id);

            if (category == null)
            {
                return NotFound($"Category with ID {Id} not found.");
            }

            return Ok(_mapper.Map<CategoryDTO>(category));
        }        [HttpPost(Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDTO>> AddCategory(CategoryDTO newCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid category data.");
            }

            long categoryId = await oCategory.Add(_mapper.Map<TbCategory>(newCategory));

            if (categoryId <= 0)
            {
                return BadRequest("Failed to add category.");
            }

            newCategory.Id = categoryId;

            return CreatedAtRoute("GetCategoryById", new { id = categoryId }, newCategory);
        }        [HttpPut("{Id:long:min(1)}", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(long Id, CategoryDTO updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid category data.");
            }

            if (!await oCategory.IsExists(Id))
            {
                return NotFound($"Category with ID {Id} not found.");
            }

            updatedCategory.Id = Id;

            if (!await oCategory.Update(_mapper.Map<TbCategory>(updatedCategory)))
            {
                return BadRequest("Failed to update category.");
            }

            return Ok(updatedCategory);
        }        [HttpGet("All", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories(int pageNumber = 1, int pageSize = 50)
        {
            var categoriesList = await oCategory.GetAll(pageNumber, pageSize);
            if (categoriesList.Count == 0)
            {
                return NotFound("No Categories Found!");
            }
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categoriesList));
        }        [HttpGet("IsExists/{Id:long:min(1)}", Name = "IsCategoryExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsCategoryExists(long Id)
        {
            bool exists = await oCategory.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Category Not Found!" });
            }
            return Ok(new { Message = "Category Exists" });
        }

        [HttpGet("Count", Name = "GetCategoriesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<long>> GetCategoriesCount()
        {
            return Ok(await oCategory.Count());
        }

        [HttpDelete("{Id:long:min(1)}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategory(long Id)
        {        
            if (await oCategory.Delete(Id))
            {
                return Ok($"Category with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Category with ID {Id} not found. No rows deleted!");
            }
        }

    }
}