using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand;
using static WebAPI.Application.AuthorOperations.Commands.UpdateAuthorCommand;
using static WebAPI.Application.AuthorOperations.Queries.GetAuthorDetailQuery;
using WebAPI.Application.AuthorOperations.Commands;
using WebAPI.Application.AuthorOperations.Queries;
using WebAPI.Models;
using WebAPI.Validators;
using WebAPI.Validators.AuthorValidators;
using FluentValidation;
using FluentValidation.Results;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AuthorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery getAuthorsQuery = new GetAuthorsQuery(_appDbContext);
            var result = getAuthorsQuery.Handle();
            return Ok(result);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AuthorDetailViewModel AuthorDetailViewModel;
            try
            {
                GetAuthorDetailQuery getAuthorDetailQuery = new GetAuthorDetailQuery(_appDbContext);
                getAuthorDetailQuery.AuthorId = id;
                //GetAuthorValidator validator = new GetAuthorValidator();
                //ValidationResult result = validator.Validate(getAuthorDetailQuery);

                //validator.ValidateAndThrow(getAuthorDetailQuery);
                AuthorDetailViewModel = getAuthorDetailQuery.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(AuthorDetailViewModel);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel AuthorModel)
        {
            CreateAuthorCommand createAuthorCommand = new CreateAuthorCommand(_appDbContext);
            createAuthorCommand.Model = AuthorModel;
            CreateAuthorValidator validator = new CreateAuthorValidator();
            ValidationResult result = validator.Validate(createAuthorCommand);

            validator.ValidateAndThrow(createAuthorCommand);
            createAuthorCommand.Handle();

            return Ok();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel AuthorModel)
        {
            UpdateAuthorCommand updateAuthorCommand = new UpdateAuthorCommand(_appDbContext);
            try
            {
                updateAuthorCommand.AuthorId = id;
                updateAuthorCommand.Model = AuthorModel;
                UpdateAuthorValidator validator = new UpdateAuthorValidator();
                ValidationResult result = validator.Validate(updateAuthorCommand);

                validator.ValidateAndThrow(updateAuthorCommand);
                updateAuthorCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteAuthorCommand deleteAuthorCommand = new DeleteAuthorCommand(_appDbContext);
            try
            {
                deleteAuthorCommand.AuthorId = id;
                //DeleteAuthorValidator validator = new DeleteAuthorValidator();
                //ValidationResult result = validator.Validate(deleteAuthorCommand);

                //validator.ValidateAndThrow(deleteAuthorCommand);
                deleteAuthorCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
