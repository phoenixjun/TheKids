
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheKids.Domain.Models
{
    public class Language : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Child> LanguagesChild { get; set; }
        public virtual ICollection<Staff> LanguagesStaff { get; set; }

        public Language()
        {
            LanguagesChild = new Collection<Child>();
            LanguagesStaff = new Collection<Staff>();
        }
    }
}
