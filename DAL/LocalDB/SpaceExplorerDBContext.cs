using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LocalDB
{
    public class SpaceExplorerDBContext
    {
        public DbSet<Media> MediaObjects { get; set; }
        public DbSet<SearchHistory> SearchHistoryObjects { get; set; }
    }
}
