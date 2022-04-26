using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public class Media
    {
        public int MediaID { get; set; }

        public string NasaId { get; set; }

        [Required]
        public string Name { get; set; }  
        
        public string Description { get; set; }

        public string Title { get; set; }

        [Required]
        public string Uri { get; set; }
                
        public List<ImaggaTagsForImage> Tags { get; set; }

        // TimeStamp as byte[] columns cannot be used in comparisons... 
        public DateTime Day { get; set; }
    }
}
