using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase
{
    public record ApartmentCreateRequestDto(string Block, [property: RangeAttribute(1,2)] byte Status, byte Type, int Floor, int ApartmentNumber, string OwnerOrTenant,int userId);
}
