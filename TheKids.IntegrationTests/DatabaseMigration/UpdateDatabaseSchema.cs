using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using TheKids.Infrastructure.Migrations;
using TheKids.Infrastructure.Storage.EF;

namespace TheKids.IntegrationTests.DatabaseMigration
{
    [TestFixture]
    public class UpdateDatabaseSchema
    {
        [Explicit]
        public void Should_UpdateToLatestSchema()
        {
            Database.SetInitializer<TheKidsDbContext>(new MigrateDatabaseToLatestVersion<TheKidsDbContext, Configuration>());
            var context = new TheKidsDbContext();

            var addresses = context.Addresses.ToList();
        }
    }
}
