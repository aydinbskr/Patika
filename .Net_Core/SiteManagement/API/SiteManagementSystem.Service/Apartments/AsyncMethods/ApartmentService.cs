using AutoMapper;
using SiteManagementSystem.Repository;
using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Repository.Enums;
using SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Apartments.DTOs;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Apartments.AsyncMethods
{

    public class ApartmentService(IApartmentRepository ApartmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
         : IApartmentService
    {
        public async Task<ResponseModelDto<int>> Create(ApartmentCreateRequestDto request)
        {
            var newApartment = new Apartment
            {
                Block = request.Block,
                Status = (ApartmentStatus)request.Status,
                Type = (ApartmentType)request.Type,
                Floor = request.Floor,
                ApartmentNumber = request.ApartmentNumber,
                OwnerOrTenant = request.OwnerOrTenant,
                UserId = request.userId
            };

            await ApartmentRepository.Create(newApartment);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newApartment.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await ApartmentRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<ApartmentDto>>> GetAllByPage(int page, int pageSize)
        {
            var ApartmentsList = await ApartmentRepository.GetAllByPage(page, pageSize);


            var ApartmentListAsDto = mapper.Map<List<ApartmentDto>>(ApartmentsList);

            return ResponseModelDto<ImmutableList<ApartmentDto>>.Success(ApartmentListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<ApartmentDto>>> GetAll(
            )
        {
            var ApartmentList = await ApartmentRepository.GetAll();

            var ApartmentListAsDto = mapper.Map<List<ApartmentDto>>(ApartmentList);


            return ResponseModelDto<ImmutableList<ApartmentDto>>.Success(ApartmentListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ApartmentDto?>> GetById(int id)
        {
            var hasApartment = await ApartmentRepository.GetById(id);


            var ApartmentAsDto = mapper.Map<ApartmentDto>(hasApartment);

            return ResponseModelDto<ApartmentDto?>.Success(ApartmentAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int ApartmentId, ApartmentUpdateRequestDto request)
        {
            var hasApartment = await ApartmentRepository.GetById(ApartmentId);


            hasApartment.Block = request.Block;
            hasApartment.Status = (ApartmentStatus)request.Status;
            hasApartment.Type = (ApartmentType)request.Type;
            hasApartment.Floor = request.Floor;
            hasApartment.ApartmentNumber = request.ApartmentNumber;
            hasApartment.OwnerOrTenant = request.OwnerOrTenant;


            await ApartmentRepository.Update(hasApartment);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

      


    }
}
