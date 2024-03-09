using WebAPI.Models;

namespace WebAPI.Application.AuthorOperations.Commands
{
    public class UpdateAuthorCommand
    {
        private readonly AppDbContext _appDbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        public UpdateAuthorCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var Author = _appDbContext.Authors.SingleOrDefault(p => p.Id == AuthorId);
            if (Author is null)
                throw new InvalidOperationException("Yazar bulunamadı.");

            Author.Name = Model.Name != default ? Model.Name : Author.Name;
            Author.Surname = Model.Surname != default ? Model.Surname : Author.Surname;
            Author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : Author.DateOfBirth;

            _appDbContext.SaveChanges();
        }

        public class UpdateAuthorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
