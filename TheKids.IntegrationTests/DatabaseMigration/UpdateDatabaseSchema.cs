using System.Linq;
using NUnit.Framework;
using TheKids.Infrastructure.Storage.EF;

namespace TheKids.IntegrationTests.DatabaseMigration
{
    [TestFixture]
    public class UpdateDatabaseSchema
    {
        [Test]
        public void Should_UpdateToLatestSchema()
        {
            var context = new TheKidsDbContext();
            
            var addresses = context.Addresses.ToList();
        }
    }
}
