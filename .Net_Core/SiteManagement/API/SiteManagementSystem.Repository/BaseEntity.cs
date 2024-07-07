using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
   

        public BaseEntity()
        {
            Id = default;
        }

        public BaseEntity(T id)
        {
            Id = id;
        }
    }
}
