using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Bills
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(AppDbContext context) : base(context)
        {
        }
    }
}
