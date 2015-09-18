using System.Data.Entity;
using TheKids.Domain.Interfaces;
using TheKids.Domain.Models;
using TheKids.Infrastructure.Storage.EF.Mapping;

namespace TheKids.Infrastructure.Storage.EF
{
    public class TheKidsDbContext : DbContext, IUnitOfWork
    {
        public TheKidsDbContext() : base("TheKidsContext")
        {
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<ChildcareCenter> ChildcareCenters { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ChildcareCenterChild> ChildcareCenterChildren { get; set; }
        public DbSet<ChildAttendance> ChildAttendances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChildMap());
            modelBuilder.Configurations.Add(new ChildcareCenterMap());
            modelBuilder.Configurations.Add(new StaffMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new ChildcareCenterChildMap());
            modelBuilder.Configurations.Add(new ChildAttendanceMap());
        }
    }
}
