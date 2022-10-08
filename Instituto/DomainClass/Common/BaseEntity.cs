using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
