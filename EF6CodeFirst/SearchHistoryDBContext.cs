using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace EF6CodeFirst
{
    public class SearchHistoryDBContext : DbContext
    {
        public SearchHistoryDBContext() : base("SearchHistoryDB")
        {
            // This initializer drops an existing database and creates a new database,
            // if your model classes (entity classes) have been changed.
            // So, you don't have to worry about maintaining your database schema, when your model classes change.
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SearchHistoryDBContext>());
        }

        public DbSet<SearchHistory> Objects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchHistory>().MapToStoredProcedures();
        }
    }
}
