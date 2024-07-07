using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.DTOs
{
    public record UserUpdateRequestDto(string FullName, string NationalId, string Email, string Phone, string UserType);
}
