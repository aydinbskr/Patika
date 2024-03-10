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
    public static class Genres
    {
        public static void AddGenres(this AppDbContext appDbContext)
        {
            appDbContext.Genres.AddRange(
               new Genre
               {
                   Name = "Personal Growth"
               },
               new Genre
               {
                   Name = "Science Finction"
               }
               );
        }
    }
}
