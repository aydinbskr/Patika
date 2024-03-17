using AutoMapper;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class CreateMovieCommand
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CreateMovieModel Model { get; set; }
        public CreateMovieCommand(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _appDbContext.Movies.SingleOrDefault(p => p.Name == Model.Name);
            if (movie is not null)
                throw new InvalidOperationException("Movie zaten var!");

            movie = _mapper.Map<Movie>(Model);

            _appDbContext.Movies.Add(movie);
            _appDbContext.SaveChanges();
        }

        public class CreateMovieModel
        {
            public string Name { get; set; }
            public string Year { get; set; }
            public int MovieTypeId { get; set; }
            public double Price { get; set; }
            public int DirectorId { get; set; }
        }
    }
}
