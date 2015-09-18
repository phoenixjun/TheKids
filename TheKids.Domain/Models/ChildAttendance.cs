
using System;

namespace TheKids.Domain.Models
{
    public class ChildAttendance : EntityBase
    {
        public int ChildAttendanceId { get; set; }
        public int ChildcareCenterChildId { get; set; }
        public virtual ChildcareCenterChild ChildcareCenterChild { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Comment { get; set; }
    }
}
