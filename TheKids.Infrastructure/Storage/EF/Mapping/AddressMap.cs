using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class AddressMap : EntityBaseMap<Address>
    {
        public AddressMap()
        {
            Property(t => t.Address1).IsRequired().HasMaxLength(100);
            Property(t => t.Address2).HasMaxLength(100);
            Property(t => t.Address3).HasMaxLength(100);
            Property(t => t.Country).HasMaxLength(50);
            Property(t => t.State).HasMaxLength(50);
            Property(t => t.Suburb).HasMaxLength(50);
            Property(t => t.Postcode).HasMaxLength(10);
            ToTable("Address");
        }
    }
}
