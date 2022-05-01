using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public class ImaggaTagForImage
    {
        private string tag;      
        private double confidence;      
        
        [Key]
        [Column(Order = 1)]
        public string Tag { get => tag; set => tag = value; }

        [Key]
        [Column(Order = 2)]
        public double Confidence { get => confidence; set => confidence = value; }

    }
}
