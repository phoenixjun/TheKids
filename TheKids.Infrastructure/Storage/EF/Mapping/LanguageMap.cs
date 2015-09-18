using System.Data.Entity.ModelConfiguration;
using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            Property(t => t.Code).IsRequired().HasMaxLength(10);
            Property(t => t.Name).IsRequired().HasMaxLength(50);

            ToTable("Language").HasKey(c => c.Code);
        }

    }
}
