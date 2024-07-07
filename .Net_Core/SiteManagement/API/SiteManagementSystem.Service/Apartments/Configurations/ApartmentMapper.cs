using AutoMapper;
using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Apartments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteManagementSystem.Service.Apartments.Configurations
{
    public class ApartmentMapper : Profile
    {
        public ApartmentMapper()
        {
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<Apartment, ApartmentUpdateRequestDto>().ReverseMap();
            CreateMap<Apartment, ApartmentCreateRequestDto>().ReverseMap();

        }
    }
}
