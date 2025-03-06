using BookHub.WebApi.Dtos;
using BookHub.WebApi.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IValidator<CreateBookDto> _createBookDto;
        private readonly IValidator<UpdateBookDto> _updateBookValidator;

        public BookController(IBookService bookService, IValidator<CreateBookDto> createBookDto, IValidator<UpdateBookDto> updateBookValidator)
        {
            _bookService = bookService;
            _createBookDto = createBookDto;
            _updateBookValidator = updateBookValidator;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAll();

            if (!books.Any())
            {
                return Ok(new List<CreateBookDto>());
            }

            return Ok(books);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById([FromQuery] int id)
        {
            var book = _bookService.GetById(id);
            if (book is null)
            {
                return BadRequest("Book not found");
            }
            return Ok(book);
        }

        [HttpGet("get-by-isbn")]
        public IActionResult GetByIsbn([FromQuery] string isbn)
        {
            var book = _bookService.GetByIsbn(isbn);
            if (book is null)
            {
                return BadRequest("Book not found");
            }
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] CreateBookDto bookDto)
        {
            var validationResult = _createBookDto.Validate(bookDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            _bookService.Create(bookDto);
            return Ok(bookDto);
        }

        [HttpPut("update-book")]
        public IActionResult UpdateBook([FromQuery] int id, [FromBody] UpdateBookDto updateBookDto)
        {
            var validationResult = _updateBookValidator.Validate(updateBookDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            var bookDto = _bookService.Update(id, updateBookDto);
            return Ok(bookDto);
        }

        [HttpDelete("delete-book")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            
            var isDelete = _bookService.Delete(id);
            return Ok(isDelete);
        }
    }
}
