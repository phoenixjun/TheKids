using System.Data.Entity.ModelConfiguration;
using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
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
            Property(t => t.CreatedBy).IsRequired().HasMaxLength(100);
            Property(t => t.UpdatedBy).IsRequired().HasMaxLength(100);

            ToTable("ResidentialAddress");
        }
    }
}
