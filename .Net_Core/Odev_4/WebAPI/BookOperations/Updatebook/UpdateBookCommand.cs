using WebAPI.Models;

namespace WebAPI.BookOperations.Updatebook
{
    public class UpdateBookCommand
    {
        private readonly AppDbContext _appDbContext;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var book = _appDbContext.Books.SingleOrDefault(p => p.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _appDbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; } = string.Empty;
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
