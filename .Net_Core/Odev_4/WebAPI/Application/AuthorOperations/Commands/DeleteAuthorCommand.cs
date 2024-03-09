using WebAPI.Models;

namespace WebAPI.Application.AuthorOperations.Commands
{
    public class DeleteAuthorCommand
    {
        private readonly AppDbContext _appDbContext;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var author = _appDbContext.Authors.SingleOrDefault(p => p.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı.");

            _appDbContext.Authors.Remove(author);
            _appDbContext.SaveChanges();
        }


    }
}
