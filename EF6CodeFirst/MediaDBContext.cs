using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst
{
    public class MediaDBContext : DbContext
    {
        public MediaDBContext() : base("MediaDB")
        {
            // This initializer drops an existing database and creates a new database,
            // if your model classes (entity classes) have been changed.
            // So, you don't have to worry about maintaining your database schema, when your model classes change.
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MediaDBContext>());


            // Disable initializer
            // Suppose that you don't want to lose existing data in the production environment, then you can turn off the initializer:
            //Database.SetInitializer<MediaDBContext>(null);
        }

        public DbSet<Media> Objects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>().MapToStoredProcedures();
        }
    }
}
