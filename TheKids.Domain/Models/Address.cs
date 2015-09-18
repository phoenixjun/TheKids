using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheKids.Domain.Models
{
    public class Address : EntityBase
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }

        public virtual ICollection<Child> ResidentialAddressChildren { get; set; } 
        public virtual ICollection<Child> MailingAddressChildren { get; set; }
        public virtual ICollection<ChildcareCenter> AddressChildcareCenters { get; set; }
        public virtual ICollection<ChildcareCenter> MailingAddressChildcareCenters { get; set; }
        public virtual ICollection<Staff> ResidentialAddressStaves { get; set; }
        public virtual ICollection<Staff> MailingAddressStaves { get; set; }


        public Address()
        {
            ResidentialAddressStaves = new Collection<Staff>();
            MailingAddressStaves = new Collection<Staff>();
            MailingAddressChildren = new Collection<Child>();
            ResidentialAddressChildren = new Collection<Child>();
            AddressChildcareCenters = new Collection<ChildcareCenter>();
            MailingAddressChildcareCenters = new Collection<ChildcareCenter>();
        }
    }
}