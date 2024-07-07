using SiteManagementSystem.Service.Bills.BillCreateUseCase;
using SiteManagementSystem.Service.Bills.DTOs;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills.AsyncMethods
{
    public interface IBillService
    {
        Task<ResponseModelDto<ImmutableList<BillDto>>> GetAll();


        Task<ResponseModelDto<BillDto?>> GetById(int id);

        Task<ResponseModelDto<ImmutableList<BillDto>>> GetAllByPage(int page, int pageSize);


        Task<ResponseModelDto<int>> Create(BillCreateRequestDto request);
        Task<ResponseModelDto<NoContent>> Update(int BillId, BillUpdateRequestDto request);




        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}
