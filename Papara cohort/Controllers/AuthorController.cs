using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Papara_cohort.Model;
using Papara_cohort.UnitOfWork;
using FluentValidation;

namespace Papara_cohort.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Author> _authorValidator;

        public AuthorController(IUnitOfWork unitOfWork, IValidator<Author> authorValidator)
        {
            _unitOfWork = unitOfWork;
            _authorValidator = authorValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            var validationResult = await _authorValidator.ValidateAsync(author);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _unitOfWork.AuthorRepository.Insert(author);
            await _unitOfWork.Complete();

            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            var existingAuthor = await _unitOfWork.AuthorRepository.GetById(id);
            if (existingAuthor == null)
                return NotFound();

            var validationResult = await _authorValidator.ValidateAsync(author);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingAuthor.Name = author.Name;
            existingAuthor.DateOfBirth = author.DateOfBirth;
            // Diğer özellikleri güncelle

            _unitOfWork.AuthorRepository.Update(existingAuthor);
            await _unitOfWork.Complete();

            return Ok(existingAuthor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetById(id);
            if (author == null)
                return NotFound();

            await _unitOfWork.AuthorRepository.Delete(id);
            await _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _unitOfWork.AuthorRepository.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }
    }
}
