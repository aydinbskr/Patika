using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }

            context.Books.AddRange(
               new Book()
               {
                   Title = "Lean Startup",
                   GenreId = (int)GenreEnum.PersonalGrowth, // Personal Growth
                   PageCount = 200,
                   PublishDate = new DateTime(2001, 06, 12)
               });

            context.SaveChanges();
        }
    }
}