using SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Apartments.DTOs;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Apartments.AsyncMethods
{
    public interface IApartmentService
    {
        Task<ResponseModelDto<ImmutableList<ApartmentDto>>> GetAll();


        Task<ResponseModelDto<ApartmentDto?>> GetById(int id);

        Task<ResponseModelDto<ImmutableList<ApartmentDto>>> GetAllByPage(int page, int pageSize);


        Task<ResponseModelDto<int>> Create(ApartmentCreateRequestDto request);
        Task<ResponseModelDto<NoContent>> Update(int ApartmentId, ApartmentUpdateRequestDto request);

        


        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}
