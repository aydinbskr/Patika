using WebAPI.Models;

namespace WebAPI.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQuery
    {
        private readonly AppDbContext _appDbContext;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _appDbContext.Authors.SingleOrDefault(p => p.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı.");
            AuthorDetailViewModel authorDetailViewModel = new AuthorDetailViewModel
            {
                Name = author.Name,
                Surname = author.Surname,
                DateOfBirth = author.DateOfBirth
            };
            return authorDetailViewModel;
        }

        public class AuthorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
