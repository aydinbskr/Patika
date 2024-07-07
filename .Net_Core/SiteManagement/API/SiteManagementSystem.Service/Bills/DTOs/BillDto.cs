using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills.DTOs
{
    public record BillDto(int Id, int ApartmentId, decimal Amount, string Type, DateTime DueDate, string IsPaid);
}
