using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core
{
    public abstract class BaseEntity
    {
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? ModifiedTime  { get; set; }
        public bool IsActive { get; set; }

        protected BaseEntity()
        {
            CreatedTime = DateTime.UtcNow;
        }
    }
}
