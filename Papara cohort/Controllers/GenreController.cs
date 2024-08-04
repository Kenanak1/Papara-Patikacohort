using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Papara_cohort.Model;
using Papara_cohort.UnitOfWork;
using FluentValidation;

namespace Papara_cohort.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Genre> _genreValidator;

        public GenreController(IUnitOfWork unitOfWork, IValidator<Genre> genreValidator)
        {
            _unitOfWork = unitOfWork;
            _genreValidator = genreValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] Genre genre)
        {
            var validationResult = await _genreValidator.ValidateAsync(genre);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _unitOfWork.GenreRepository.Insert(genre);
            await _unitOfWork.Complete();

            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] Genre genre)
        {
            var existingGenre = await _unitOfWork.GenreRepository.GetById(id);
            if (existingGenre == null)
                return NotFound();

            var validationResult = await _genreValidator.ValidateAsync(genre);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingGenre.Name = genre.Name;
            // Diğer özellikleri güncelle

            _unitOfWork.GenreRepository.Update(existingGenre);
            await _unitOfWork.Complete();

            return Ok(existingGenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _unitOfWork.GenreRepository.GetById(id);
            if (genre == null)
                return NotFound();

            await _unitOfWork.GenreRepository.Delete(id);
            await _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _unitOfWork.GenreRepository.GetAll();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _unitOfWork.GenreRepository.GetById(id);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }
    }
}
