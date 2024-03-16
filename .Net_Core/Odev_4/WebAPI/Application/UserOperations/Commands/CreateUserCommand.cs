using AutoMapper;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Application.UserOperations.Commands
{
    public class CreateUserCommand
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CreateUserModel Model { get; set; }
        public CreateUserCommand(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _appDbContext.Users.SingleOrDefault(p => p.Email == Model.Email);
            if (user is not null)
                throw new InvalidOperationException("User zaten var!");

            user = _mapper.Map<User>(Model);

            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string SurName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
