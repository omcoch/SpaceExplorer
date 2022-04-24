using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.LocalDB
{
    public class SpaceExplorerDBContext : DbContext
    {
        public DbSet<DataProtocol.Media> MediaObjects { get; set; }
        public DbSet<DataProtocol.SearchHistory> SearchHistoryObjects { get; set; }

        public SpaceExplorerDBContext() : base("SpaceExplorerDBContext")
        {
            // This initializer drops an existing database and creates a new database,
            // if your model classes (entity classes) have been changed.
            // So, you don't have to worry about maintaining your database schema, when your model classes change.
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SpaceExplorerDBContext>());


            // Disable initializer
            // Suppose that you don't want to lose existing data in the production environment, then you can turn off the initializer:
            //Database.SetInitializer<MediaDBContext>(null);
        }

        

    }
}
