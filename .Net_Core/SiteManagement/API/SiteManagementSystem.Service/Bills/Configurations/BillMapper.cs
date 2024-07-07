using AutoMapper;
using SiteManagementSystem.Repository.Bills;
using SiteManagementSystem.Service.Bills.BillCreateUseCase;
using SiteManagementSystem.Service.Bills.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills.Configurations
{
    public class BillMapper : Profile
    {
        public BillMapper()
        {
            CreateMap<Bill, BillDto>().ReverseMap();
            CreateMap<Bill, BillUpdateRequestDto>().ReverseMap();
            CreateMap<Bill, BillCreateRequestDto>().ReverseMap();

        }
    }
}
