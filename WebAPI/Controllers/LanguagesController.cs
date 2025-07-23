using Microsoft.AspNetCore.Mvc;
using ECommerce.Bl;
using ECommerce.DTO;
using ECommerce.Models;
using AutoMapper;

namespace ECommerce.Controllers
{
    [Route("api/v1/Languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {        ILanguage oLanguage;
        private readonly IMapper _mapper;
        public LanguagesController(ILanguage language, IMapper mapper)
        {
            oLanguage = language;
            _mapper = mapper;
        }        [HttpGet("ById/{Id:int:min(1)}", Name = "GetLanguageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LanguageDTO>> GetLanguageById(int Id)
        {
            TbLanguage language = await oLanguage.GetById(Id);

            if (language == null)
            {
                return NotFound($"Language with ID {Id} not found.");
            }

            return Ok(_mapper.Map<LanguageDTO>(language));
        }        [HttpPost(Name = "AddLanguage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LanguageDTO>> AddLanguage(LanguageDTO newLanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid language data.");
            }

            int languageId = await oLanguage.Add(_mapper.Map<TbLanguage>(newLanguage));

            if (languageId <= 0)
            {
                return BadRequest("Failed to add language.");
            }

            newLanguage.Id = languageId;

            return CreatedAtRoute("GetLanguageById", new { id = languageId }, newLanguage);
        }        [HttpPut("{Id:int:min(1)}", Name = "UpdateLanguage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LanguageDTO>> UpdateLanguage(int Id, LanguageDTO updatedLanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid language data.");
            }

            if (!await oLanguage.IsExists(Id))
            {
                return NotFound($"Language with ID {Id} not found.");
            }

            updatedLanguage.Id = Id;

            if (!await oLanguage.Update(_mapper.Map<TbLanguage>(updatedLanguage)))
            {
                return BadRequest("Failed to update language.");
            }

            return Ok(updatedLanguage);
        }        [HttpGet("All", Name = "GetAllLanguages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<LanguageDTO>>> GetAllLanguages(int pageNumber = 1, int pageSize = 50)
        {
            var languagesList = await oLanguage.GetAll(pageNumber, pageSize);
            if (languagesList.Count == 0)
            {
                return NotFound("No Languages Found!");
            }
            return Ok(_mapper.Map<IEnumerable<LanguageDTO>>(languagesList));
        }        [HttpGet("IsExists/{Id:int:min(1)}", Name = "IsLanguageExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsLanguageExists(int Id)
        {
            bool exists = await oLanguage.IsExists(Id);
            if (!exists)
            {
                return NotFound(new { Message = "Language Not Found!" });
            }
            return Ok(new { Message = "Language Exists" });
        }

        [HttpGet("Count", Name = "GetLanguagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetLanguagesCount()
        {
            return Ok(await oLanguage.Count());
        }

        [HttpDelete("{Id:int:min(1)}", Name = "DeleteLanguage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteLanguage(int Id)
        {        
            if (await oLanguage.Delete(Id))
            {
                return Ok($"Language with ID {Id} has been deleted.");
            }
            else
            {
                return NotFound($"Language with ID {Id} not found. No rows deleted!");
            }
        }

    }
}