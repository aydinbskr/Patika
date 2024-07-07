using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.ApatmentCreateUseCase
{
    public record UserCreateRequestDto(string FullName, string NationalId, string Email, string Phone, string UserType);
}
