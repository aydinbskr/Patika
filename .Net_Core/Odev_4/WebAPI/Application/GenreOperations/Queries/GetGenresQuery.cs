using WebAPI.Models;

namespace WebAPI.Application.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        private readonly AppDbContext _appDbContext;

        public GetGenresQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _appDbContext.Genres
                .Where(p => p.IsActive)
                .OrderBy(p => p.Id)
                .Select(p => new GenresViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

            return genres;

        }
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
