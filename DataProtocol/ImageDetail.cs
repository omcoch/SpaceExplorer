using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public class ImageDetail
    {
        public string ImageUri { get; set; }
        public string ImageDescription { get; set; }
        public string ImageTitle { get; set; }

        public ImageDetail()
        {
            FillMockDetail();
        }

        private void FillMockDetail()
        {
            ImageDescription = "פרטים פרטים";
            ImageTitle = "The Title";
            ImageUri = @"C:\Users\nocks\source\repos\SpaceExplorer\SpaceExplorer\Assets\Images\try.jpg";
        }
    }
}
