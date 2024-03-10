using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.UnitTests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this AppDbContext appDbContext)
        {
            appDbContext.Books.AddRange(
               new Book()
               {
                   Title = "Lean Startup",
                   GenreId = 1, // Personal Growth
                   PageCount = 200,
                   PublishDate = new DateTime(2001, 06, 12)
               });
        }
    }
}
