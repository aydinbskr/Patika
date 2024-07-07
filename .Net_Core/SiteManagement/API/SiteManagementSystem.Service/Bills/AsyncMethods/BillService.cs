using AutoMapper;
using SiteManagementSystem.Repository.Bills;
using SiteManagementSystem.Repository;
using SiteManagementSystem.Service.Bills.AsyncMethods;
using SiteManagementSystem.Service.Bills.DTOs;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SiteManagementSystem.Service.Bills.BillCreateUseCase;

namespace SiteManagementSystem.Service.Bills.AsyncMethods
{
    public class BillService(IBillRepository BillRepository, IUnitOfWork unitOfWork, IMapper mapper)
         : IBillService
    {
        public async Task<ResponseModelDto<int>> Create(BillCreateRequestDto request)
        {
            var newBill = new Bill
            {
                ApartmentId = request.ApartmentId,
                Amount = request.Amount,
                Type = request.Type,
                DueDate = request.DueDate,
                IsPaid = request.IsPaid
            };

            await BillRepository.Create(newBill);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newBill.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await BillRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<BillDto>>> GetAllByPage(int page, int pageSize)
        {
            var BillsList = await BillRepository.GetAllByPage(page, pageSize);


            var BillListAsDto = mapper.Map<List<BillDto>>(BillsList);

            return ResponseModelDto<ImmutableList<BillDto>>.Success(BillListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<BillDto>>> GetAll(
            )
        {
            var BillList = await BillRepository.GetAll();

            var BillListAsDto = mapper.Map<List<BillDto>>(BillList);


            return ResponseModelDto<ImmutableList<BillDto>>.Success(BillListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<BillDto?>> GetById(int id)
        {
            var hasBill = await BillRepository.GetById(id);


            var BillAsDto = mapper.Map<BillDto>(hasBill);

            return ResponseModelDto<BillDto?>.Success(BillAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int BillId, BillUpdateRequestDto request)
        {
            var hasBill = await BillRepository.GetById(BillId);


            hasBill.ApartmentId = request.ApartmentId;
            hasBill.Amount = request.Amount;
            hasBill.Type = request.Type;
            hasBill.Type = request.Type;
            hasBill.DueDate = request.DueDate;
            hasBill.IsPaid = request.IsPaid;


            await BillRepository.Update(hasBill);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }




    }
}
