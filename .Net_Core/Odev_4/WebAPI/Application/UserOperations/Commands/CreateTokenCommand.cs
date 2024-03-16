using AutoMapper;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.TokenOperations;
using WebAPI.TokenOperations.Models;

namespace WebAPI.Application.UserOperations.Commands
{
    public class CreateTokenCommand
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public TokenModel Model { get; set; }
        public CreateTokenCommand(IAppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _appDbContext.Users.FirstOrDefault(p => p.Email == Model.Email && p.Password==Model.Password);
            if (user is null)
                throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı!");

            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            
            _appDbContext.SaveChanges();
            return token;
        }

        public class TokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
