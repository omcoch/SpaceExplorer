using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public class SearchHistory
    {
        [Key]
        [MaxLength(100)]
        public string SearchTerm { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
