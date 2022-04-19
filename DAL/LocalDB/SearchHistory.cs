using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LocalDB
{
    public class SearchHistory
    {
        [Key]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string SearchTerm { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
