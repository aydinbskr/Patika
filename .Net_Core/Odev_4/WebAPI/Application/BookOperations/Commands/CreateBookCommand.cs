using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Application.BookOperations.Commands
{
    public class CreateBookCommand
    {
        private readonly IAppDbContext _appDbContext;
        public CreateBookModel Model { get; set; }
        public CreateBookCommand(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var book = _appDbContext.Books.SingleOrDefault(p => p.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Book zaten var!");

            Book dbBook = new Book
            {
                GenreId = Model.GenreId,
                PageCount = Model.PageCount,
                PublishDate = Model.PublishDate,
                Title = Model.Title
            };

            _appDbContext.Books.Add(dbBook);
            _appDbContext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; } = string.Empty;
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
