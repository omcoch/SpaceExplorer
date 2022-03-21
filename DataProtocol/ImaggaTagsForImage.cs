using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public  class ImaggaTagsForImage
    {
        private string ImageName;
        private List<string> tags = new List<string>();
        public string imageUri { get => ImageName; set => ImageName=value; }
        public List<string> Tags { get => tags; set => tags = value; }
    }
}
