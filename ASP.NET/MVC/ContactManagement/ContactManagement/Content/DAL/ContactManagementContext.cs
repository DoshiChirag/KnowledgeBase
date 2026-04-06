using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ContactManagement.Models;
namespace ContactManagement.DAL
{
    public class ContactManagementContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}