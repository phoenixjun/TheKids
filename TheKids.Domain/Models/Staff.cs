using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheKids.Domain.Enums;

namespace TheKids.Domain.Models
{
    public class Staff : EntityBase
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Gender Gender { get; set; }
        public virtual Address ResidentialAddress { get; set; }
        public int ResidentialAddressId { get; set; }
        public virtual Address MailingAddress { get; set; }
        public int? MailingAddressId { get; set; }
        public bool UseAddress { get; set; }
        public int ChildcareCenterId { get; set; }
        public virtual ChildcareCenter ChildcareCenter { get; set; }
        public virtual ICollection<Language> Languages { get; set; }

        public Staff()
        {
            Languages = new Collection<Language>();
        }
    }
}