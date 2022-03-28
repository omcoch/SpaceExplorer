using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst
{
    /* 
     Instead of designing database tables first, let's start creating classes for our images, as and when needed.
     First, create the Student and Grade classes where every Student is associated with one Grade as shown below.
     This is called a one-to-many relationship.
    */
    public class Media
    {
        public int MediaID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        [Required]
        public string Uri { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
