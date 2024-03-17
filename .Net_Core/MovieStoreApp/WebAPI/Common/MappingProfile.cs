using AutoMapper;
using WebAPI.Entities;
using static WebAPI.Application.MovieOperations.Commands.CreateMovieCommand;

namespace WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieModel, Movie>();
            //CreateMap<Movie, CreateMovieModel>().ForMember(dest => dest.MovieTypeId, opt => opt.MapFrom(src => src.Genre.Name));
            //CreateMap<CreateUserModel, User>();
        }
    }
}
