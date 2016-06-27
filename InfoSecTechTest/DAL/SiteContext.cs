using InfoSecTechTest.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InfoSecTechTest.DAL
{
    public class SiteContext : DbContext
    {

        public SiteContext() : base("SiteContext")
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}