using System.Data.Entity.ModelConfiguration;
using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            Property(t => t.CreatedBy).IsRequired().HasMaxLength(100);
            Property(t => t.UpdatedBy).IsRequired().HasMaxLength(100);
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.LastName).IsRequired().HasMaxLength(100);
            Property(t => t.MiddleName).IsRequired().HasMaxLength(100);
            Property(t => t.ContactNumber).IsRequired().HasMaxLength(20);
            Property(t => t.ContactNumber).IsRequired().HasMaxLength(50);

            HasMany(t => t.Languages)
                .WithMany(t => t.LanguagesStaff)
                .Map(t => t.ToTable("StaffLanguage").MapLeftKey("Code").MapRightKey("StaffId"));


            HasRequired(t => t.ResidentialAddress)
                .WithMany(t => t.ResidentialAddressStaves)
                .HasForeignKey(t => t.ResidentialAddressId).WillCascadeOnDelete(false);

            HasRequired(t => t.ChildcareCenter)
                .WithMany(t => t.Stafves)
                .HasForeignKey(t => t.ChildcareCenterId)
                .WillCascadeOnDelete(false);

            HasOptional(t => t.MailingAddress)
                .WithMany(t => t.MailingAddressStaves)
                .HasForeignKey(t => t.MailingAddressId).WillCascadeOnDelete(false);
            ToTable("Staff");
        }
    }
}
