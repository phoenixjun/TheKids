
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheKids.Domain.Models
{
    /// <summary>
    /// this model stores ONE relationship between a child and a childcare center
    /// if a child enroll in a childcare center and leave and then comes back again
    /// there should be two record in the system
    /// </summary>
    public class ChildcareCenterChild : EntityBase
    {
        public int ChildcareCenterChildId { get; set; }
        public int ChildId { get; set; }
        public int ChildcareCenterId { get; set; }
        public virtual Child Child { get; set; }
        public virtual ChildcareCenter ChildcareCenter { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public ICollection<ChildAttendance> Attendances { get; set; }

        public ChildcareCenterChild()
        {
            Attendances = new Collection<ChildAttendance>();
        }
    }
}
