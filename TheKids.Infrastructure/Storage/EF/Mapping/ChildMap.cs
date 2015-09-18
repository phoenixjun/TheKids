using System.Data.Entity.ModelConfiguration;
using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class ChildMap : EntityBaseMap<Child>
    {
        public ChildMap()
        {
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.MiddleName).IsRequired().HasMaxLength(100);
            Property(t => t.LastName).IsRequired().HasMaxLength(100);
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);

            HasMany(t => t.Languages)
                .WithMany(t => t.LanguagesChild)
                .Map(t => t.ToTable("ChildLanguage")
                    .MapLeftKey("Code")
                    .MapRightKey("ChildId"));

            HasMany(t => t.ChildcareCenterChildren).WithRequired(t => t.Child).
                HasForeignKey(t => t.ChildId)
                .WillCascadeOnDelete(false);

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
