using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository.Enums
{
    public enum ApartmentType
    {
        [Description("2+1")]
        Two_Plus_One = 1,
        [Description("3+1")]
        Three_Plus_One = 2,
    }
}
