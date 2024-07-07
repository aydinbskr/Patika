using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Repository.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Users
{
    public class User:BaseEntity<int>
    {
        
        public string FullName { get; set; }
        public string NationalId { get; set; } // TCNo
        public string Email { get; set; }
        public string Phone { get; set; }
        

        public string UserType { get; set; } // "Admin" or "Resident"

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Apartment Apartment { get; set; }

        public User()
        {
        }

        public User(int ıd, string fullName, string nationalId, string email, string phone, string userType)
        {
            Id = ıd;
            FullName = fullName;
            NationalId = nationalId;
            Email = email;
            Phone = phone;
            UserType = userType;
        }

      
    }
}
