
using System;

namespace TheKids.Domain.Models
{
    public class EntityBase
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }

        protected EntityBase()
        {
            CreatedTime = DateTime.Now;
        }
    }
}
