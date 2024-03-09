using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.BookOperations.Queries;
using WebAPI.Application.GenreOperations.Queries;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GenreController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery getGenresQuery = new GetGenresQuery(_appDbContext);
            var result = getGenresQuery.Handle();
            return Ok(result);
        }
    }
}
