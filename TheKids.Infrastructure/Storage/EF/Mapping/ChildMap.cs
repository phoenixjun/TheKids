using System.Data.Entity.ModelConfiguration;
using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class ChildMap : EntityTypeConfiguration<Child>
    {
        public ChildMap()
        {
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.MiddleName).IsRequired().HasMaxLength(100);
            Property(t => t.LastName).IsRequired().HasMaxLength(100);
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.CreatedBy).IsRequired().HasMaxLength(100);
            Property(t => t.UpdatedBy).IsRequired().HasMaxLength(100);

            HasMany(t => t.Languages)
                .WithMany(t => t.LanguagesChild)
                .Map(t => t.ToTable("ChildLanguage").MapLeftKey("Code").MapRightKey("ChildId"));

            HasMany(t => t.Childcares)
                .WithMany(t => t.Children)
                .Map(t => t.ToTable("ChildcareCenterChild").
                    MapLeftKey("ChildId").
                    MapRightKey("ChildcareCenterId"));

            HasRequired(t => t.ResidentialAddress)
                .WithMany(t => t.ResidentialAddressChildren)
                .HasForeignKey(t => t.ResidentialAddressId).WillCascadeOnDelete(false);

            HasOptional(t => t.MailingAddress)
                .WithMany(t => t.MailingAddressChildren)
                .HasForeignKey(t => t.MailingAddressId).WillCascadeOnDelete(false);
            ToTable("Child");
        }
    }
}
