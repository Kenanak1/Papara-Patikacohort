using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Papara_cohort.Model;
using Papara_cohort.UnitOfWork;
using FluentValidation;

namespace Papara_cohort.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Book> _bookValidator;

        public BookController(IUnitOfWork unitOfWork, IValidator<Book> bookValidator)
        {
            _unitOfWork = unitOfWork;
            _bookValidator = bookValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var validationResult = await _bookValidator.ValidateAsync(book);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _unitOfWork.BookRepository.Insert(book);
            await _unitOfWork.Complete();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = await _unitOfWork.BookRepository.GetById(id);
            if (existingBook == null)
                return NotFound();

            var validationResult = await _bookValidator.ValidateAsync(book);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingBook.Title = book.Title;
            existingBook.PageCount = book.PageCount;
            existingBook.PublishedDate = book.PublishedDate;
            // Diğer özellikleri güncelle

            _unitOfWork.BookRepository.Update(existingBook);
            await _unitOfWork.Complete();

            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _unitOfWork.BookRepository.GetById(id);
            if (book == null)
                return NotFound();

            await _unitOfWork.BookRepository.Delete(id);
            await _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _unitOfWork.BookRepository.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _unitOfWork.BookRepository.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }
    }
}
