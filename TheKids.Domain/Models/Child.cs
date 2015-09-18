
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheKids.Domain.Enums;

namespace TheKids.Domain.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class Child : EntityBase
    {
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public virtual Address ResidentialAddress { get; set; }
        public int ResidentialAddressId { get; set; }
        public virtual Address MailingAddress { get; set; }
        public int? MailingAddressId { get; set; }
        public bool UseResidentialAddress { get; set; }
        public virtual ICollection<ChildcareCenterChild> ChildcareCenterChildren { get; set; }
        public virtual ICollection<Language> Languages { get; set; } 

        public Child()
        {
            Languages = new Collection<Language>();
            ChildcareCenterChildren = new List<ChildcareCenterChild>();
        }
    }

    //public class ChildChildcare
    //{
    //    public virtual Child Child { get; set; }
    //    public virtual ChildChildcare ChildcareCenter { get; set; }
    //    public DateTime DateStart { get; set; }
    //    public DateTime? DateEnd { get; set; }
    //}
}
