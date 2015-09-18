
using System.Collections.Generic;

namespace TheKids.Domain.Models
{
    public class Language : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Child> LanguagesChild { get; set; }
        public virtual ICollection<Staff> LanguagesStaff { get; set; }
    }
}
