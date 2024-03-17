using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.MovieOperations.Commands;
using WebAPI.Context;
using static WebAPI.Application.MovieOperations.Commands.CreateMovieCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MoviesController(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieModel movieModel)
        {
            CreateMovieCommand createMovieCommand = new CreateMovieCommand(_appDbContext,_mapper);
            createMovieCommand.Model = movieModel;
            //CreateBookValidator validator = new CreateBookValidator();
            //ValidationResult result = validator.Validate(createBookCommand);

            //validator.ValidateAndThrow(createBookCommand);
            createMovieCommand.Handle();

            return Ok();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
