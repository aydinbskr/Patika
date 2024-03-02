using Microsoft.AspNetCore.Mvc;
using WebAPI.BookOperations.CreateBook;
using WebAPI.BookOperations.GetBookDetail;
using WebAPI.BookOperations.GetBooks;
using WebAPI.BookOperations.Updatebook;
using WebAPI.Models;
using static WebAPI.BookOperations.CreateBook.CreateBookCommand;
using static WebAPI.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebAPI.BookOperations.Updatebook.UpdateBookCommand;

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
            try
            {
                createBookCommand.Model = bookModel;
                createBookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
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
        public void Delete(int id)
        {
        }
    }
}
