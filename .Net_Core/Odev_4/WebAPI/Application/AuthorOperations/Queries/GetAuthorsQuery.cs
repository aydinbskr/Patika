using WebAPI.Models;

namespace WebAPI.Application.AuthorOperations.Queries
{
    public class GetAuthorsQuery
    {
        private readonly AppDbContext _appDbContext;

        public GetAuthorsQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<AuthorViewModel> Handle()
        {
            var Authorlist = _appDbContext.Authors.OrderBy(p => p.Id).ToList();
            List<AuthorViewModel> vm = new List<AuthorViewModel>();
            foreach (var Author in Authorlist)
            {
                vm.Add(new AuthorViewModel
                {
                    Name = Author.Name,
                    Surname = Author.Surname,
                    DateOfBirth = Author.DateOfBirth
                });
            }
            return vm;
        }

        public class AuthorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}

