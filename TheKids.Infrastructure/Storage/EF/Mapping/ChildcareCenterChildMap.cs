using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class ChildcareCenterChildMap : EntityBaseMap<ChildcareCenterChild>
    {
        public ChildcareCenterChildMap()
        {
            ToTable("ChildcareCenterChild");
        }
    }
}
