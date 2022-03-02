using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorer.Models
{
    public class ImageDetailModel
    {
        private ImageDetail DAL = new ImageDetail();

        public string ImageUri { get; set; }
        public string ImageDescription { get; set; }
        public string ImageTitle { get; set; }

        public ImageDetailModel()
        {
            ImageUri = DAL.ImageUri;
            ImageDescription = DAL.ImageDescription;
            ImageTitle = DAL.ImageTitle;
        }
    }
}
