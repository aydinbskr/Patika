﻿using WebAPI.Models;

namespace WebAPI.Application.BookOperations.Commands
{
    public class DeleteBookCommand
    {
        private readonly IAppDbContext _appDbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var book = _appDbContext.Books.SingleOrDefault(p => p.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();
        }


    }
}
