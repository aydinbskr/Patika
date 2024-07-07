using SiteManagementSystem.Repository.Enums;
using SiteManagementSystem.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Apartments
{
    public class Apartment:BaseEntity<int>
    {
        public string Block { get; set; }
        public ApartmentStatus Status { get; set; } // "Occupied" or "Vacant"
        public ApartmentType Type { get; set; } // "2+1", "3+1", etc.
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public string OwnerOrTenant { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Apartment(int id, string block, ApartmentStatus status, ApartmentType type, int floor, int apartmentNumber, string ownerOrTenant)
        {
            Id = id;
            Block = block;
            Status = status;
            Type = type;
            Floor = floor;
            ApartmentNumber = apartmentNumber;
            OwnerOrTenant = ownerOrTenant;
        }

        public Apartment()
        {
        }
    }

}
