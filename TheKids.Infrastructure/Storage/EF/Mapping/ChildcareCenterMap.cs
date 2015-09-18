using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class ChildcareCenterMap : EntityBaseMap<ChildcareCenter>
    {
        public ChildcareCenterMap()
        {
            Property(t => t.Name).IsRequired().HasMaxLength(100);
            HasRequired(t => t.Address)
                .WithMany(t => t.AddressChildcareCenters)
                .HasForeignKey(t => t.AddressId);

            HasOptional(t => t.MailingAddress)
                .WithMany(t => t.MailingAddressChildcareCenters)
                .HasForeignKey(t => t.MailingAddressId);

            ToTable("ChildcareCenter");
        }

    }
}
