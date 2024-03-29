﻿using AutoMapper;
using static WebAPI.Application.BookOperations.Commands.CreateBookCommand;
using static WebAPI.Application.BookOperations.Queries.GetBookDetailQuery;
using WebAPI.Entities;
using static WebAPI.Application.UserOperations.Commands.CreateUserCommand;

namespace WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<CreateUserModel, User>();
        }
    }
}
