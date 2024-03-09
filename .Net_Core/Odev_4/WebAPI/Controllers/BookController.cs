using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.Models;
using WebAPI.Validators;
using static WebAPI.Application.BookOperations.Commands.CreateBookCommand;
using static WebAPI.Application.BookOperations.Queries.GetBookDetailQuery;
using static WebAPI.Application.BookOperations.Commands.UpdateBookCommand;
using WebAPI.Application.BookOperations.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooksQuery = new GetBooksQuery(_appDbContext);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel bookDetailViewModel;
            try
            {
                GetBookDetailQuery getBookDetailQuery = new GetBookDetailQuery(_appDbContext);
                getBookDetailQuery.BookId = id;
                GetBookValidator validator = new GetBookValidator();
                ValidationResult result = validator.Validate(getBookDetailQuery);

                validator.ValidateAndThrow(getBookDetailQuery);
                bookDetailViewModel = getBookDetailQuery.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(bookDetailViewModel);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel bookModel)
        {
            CreateBookCommand createBookCommand = new CreateBookCommand(_appDbContext);
            createBookCommand.Model = bookModel;
            CreateBookValidator validator = new CreateBookValidator();
            ValidationResult result = validator.Validate(createBookCommand);

            validator.ValidateAndThrow(createBookCommand);
            createBookCommand.Handle();

            return Ok();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel bookModel)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_appDbContext);
            try
            {
                updateBookCommand.BookId = id;
                updateBookCommand.Model = bookModel;
                UpdateBookValidator validator = new UpdateBookValidator();
                ValidationResult result = validator.Validate(updateBookCommand);

                validator.ValidateAndThrow(updateBookCommand);
                updateBookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_appDbContext);
            try
            {
                deleteBookCommand.BookId = id;
                DeleteBookValidator validator = new DeleteBookValidator();
                ValidationResult result = validator.Validate(deleteBookCommand);

                validator.ValidateAndThrow(deleteBookCommand);
                deleteBookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
