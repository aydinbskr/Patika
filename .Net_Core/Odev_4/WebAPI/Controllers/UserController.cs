using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.BookOperations.Commands;
using WebAPI.Models;
using static WebAPI.Application.BookOperations.Commands.CreateBookCommand;
using WebAPI.Validators;
using static WebAPI.Application.UserOperations.Commands.CreateUserCommand;
using WebAPI.Application.UserOperations.Commands;
using WebAPI.TokenOperations.Models;
using static WebAPI.Application.UserOperations.Commands.CreateTokenCommand;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IAppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel userModel)
        {
            CreateUserCommand command = new CreateUserCommand(_appDbContext,_mapper);
            command.Model = userModel;
            //CreateBookValidator validator = new CreateBookValidator();
            //ValidationResult result = validator.Validate(createBookCommand);

            //validator.ValidateAndThrow(createBookCommand);
            command.Handle();

            return Ok();
        }

        [HttpPost("token")]
        public IActionResult Create([FromBody] TokenModel tokenModel)
        {
            CreateTokenCommand command = new CreateTokenCommand(_appDbContext, _mapper,_configuration);
            command.Model = tokenModel;
            //CreateBookValidator validator = new CreateBookValidator();
            //ValidationResult result = validator.Validate(createBookCommand);

            //validator.ValidateAndThrow(createBookCommand);
            var token =command.Handle();

            return Ok(token);
        }

        [HttpGet("refreshtoken")]
        public IActionResult RefreshToken([FromQuery] string refreshtoken)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_appDbContext, _mapper, _configuration);
            command.RefreshToken = refreshtoken;
            //CreateBookValidator validator = new CreateBookValidator();
            //ValidationResult result = validator.Validate(createBookCommand);

            //validator.ValidateAndThrow(createBookCommand);
            var token = command.Handle();

            return Ok(token);
        }
    }
}
