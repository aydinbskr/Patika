using WebAPI.Models;

namespace WebAPI.Application.BookOperations.Queries
{
    public class GetBookDetailQuery
    {
        private readonly AppDbContext _appDbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _appDbContext.Books.SingleOrDefault(p => p.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");
            BookDetailViewModel bookDetailViewModel = new BookDetailViewModel
            {
                Title = book.Title,
                PageCount = book.PageCount,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.ToString("dd/MM/yyyy")
            };
            return bookDetailViewModel;
        }

        public class BookDetailViewModel
        {
            public string Title { get; set; } = string.Empty;
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}
