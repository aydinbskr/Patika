﻿using WebAPI.Models;

namespace WebAPI.Application.BookOperations.Queries
{
    public class GetBooksQuery
    {
        private readonly IAppDbContext _appDbContext;

        public GetBooksQuery(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<BookViewModel> Handle()
        {
            var booklist = _appDbContext.Books.OrderBy(p => p.Id).ToList();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var book in booklist)
            {
                vm.Add(new BookViewModel
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.ToString("dd/MM/yyyy")
                });
            }
            return vm;
        }

        public class BookViewModel
        {
            public string Title { get; set; } = string.Empty;
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}
