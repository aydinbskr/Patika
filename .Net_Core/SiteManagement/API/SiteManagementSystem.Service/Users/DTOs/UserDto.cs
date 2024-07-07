using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.DTOs
{
    public record UserDto(int Id, string FullName, string NationalId, string Email, string Phone, string UserType);
}
