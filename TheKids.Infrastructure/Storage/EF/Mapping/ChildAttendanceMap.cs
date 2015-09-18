using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class ChildAttendanceMap : EntityBaseMap<ChildAttendance>
    {
        public ChildAttendanceMap()
        {
            ToTable("ChildAttendance");
        }
    }
}
