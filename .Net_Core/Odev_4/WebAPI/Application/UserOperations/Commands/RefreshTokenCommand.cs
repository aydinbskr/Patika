using AutoMapper;
using WebAPI.Models;
using WebAPI.TokenOperations;
using WebAPI.TokenOperations.Models;

namespace WebAPI.Application.UserOperations.Commands
{
    public class RefreshTokenCommand
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public string RefreshToken { get; set; }
        public RefreshTokenCommand(IAppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _appDbContext.Users.FirstOrDefault(p => p.RefreshToken == RefreshToken && p.RefreshTokenExpireDate > DateTime.Now);
            if (user is null)
                throw new InvalidOperationException("Geçersiz rfresh token!");

            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

            _appDbContext.SaveChanges();
            return token;
        }

    }
}
