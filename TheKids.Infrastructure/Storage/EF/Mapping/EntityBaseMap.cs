using System.Data.Entity.ModelConfiguration;
using TheKids.Domain.Models;

namespace TheKids.Infrastructure.Storage.EF.Mapping
{
    public abstract class EntityBaseMap<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        protected EntityBaseMap()
        {
            Property(t => t.CreatedBy).IsRequired().HasMaxLength(50);
            Property(t => t.UpdatedBy).IsRequired().HasMaxLength(50);
            Property(t => t.RowVersion).IsRowVersion();
        }
    }
}
