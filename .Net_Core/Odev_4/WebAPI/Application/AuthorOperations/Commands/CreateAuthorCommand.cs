using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Application.AuthorOperations.Commands
{
    public class CreateAuthorCommand
    {
        private readonly AppDbContext _appDbContext;
        public CreateAuthorModel Model { get; set; }
        public CreateAuthorCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var Author = _appDbContext.Authors
                .SingleOrDefault(p => p.Name == Model.Name && p.Surname == Model.Surname);
            if (Author is not null)
                throw new InvalidOperationException("Author zaten var!");

            Author dbAuthor = new Author
            {
                Name = Model.Name,
                Surname = Model.Surname,
                DateOfBirth = Model.DateOfBirth,
                
            };

            _appDbContext.Add(dbAuthor);
            _appDbContext.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
