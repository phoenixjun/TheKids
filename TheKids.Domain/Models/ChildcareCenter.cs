
using System.Collections.Generic;

namespace TheKids.Domain.Models
{
    public class ChildcareCenter : EntityBase
    {
        public int ChildcareCenterId { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int? MailingAddressId { get; set; }
        public bool UseAddress { get; set; }
        public virtual Address Address { get; set; }
        public virtual Address MailingAddress { get; set; }
        public virtual List<Staff> Stafves { get; set; }
        public virtual List<ChildcareCenterChild> ChildcareCenterChildren { get; set; } 

        public ChildcareCenter()
        {
            Stafves = new List<Staff>();
            ChildcareCenterChildren = new List<ChildcareCenterChild>();
        }
    }
}
