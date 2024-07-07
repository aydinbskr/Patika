using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Apartments
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
