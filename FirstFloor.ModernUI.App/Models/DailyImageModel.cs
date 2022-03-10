﻿using BL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorer.Models
{
    public class DailyImageModel
    {
        private PicOfTheDay BL;

        public string ImageUri { get; set; }
        public string ImageDescription { get; set; }
        public string ImageTitle { get; set; }

        public DailyImageModel()
        {
            BL = new PicOfTheDay();
            GetDailyImage();
        }

        private void GetDailyImage()
        {
            List<Image> ImageDetails = BL.GetDailyImage();
            ImageTitle = ImageDetails[0].Title;
            ImageDescription = ImageDetails[0].Description;
            ImageUri = ImageDetails[0].Uri;
        }
    }
}
