using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills.BillCreateUseCase
{
    public record BillCreateRequestDto(int ApartmentId, decimal Amount, string Type, DateTime DueDate, string IsPaid);
}
