using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Enums
{
    public enum ApartmentStatus
    {
        [Description("Occupied")]
        Occupied = 1,
        [Description("Empty")]
        Empty = 2,
    }
}
