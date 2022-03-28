﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
    [TestClass()]
    public class ImaggaApiTests
    {
        [TestMethod()]
        public void getImageTagsTest()
        {
            var results = ImaggaApi.getImageTags("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg");
            var hresuls = ImaggaApi.getImageTags("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg", "he");
            for (int i = 0; i < results.Tags.Count; i++)
            {
                Console.WriteLine("English: " + results.Tags[i] + " and now in hebrew: " + hresuls.Tags[i]);
            }
        }

        [TestMethod()]
        public void getImageCategoriesTest()
        {
            var image = NasaApi.GetDailyImage(DateTime.Parse("23/03/2022"));
            Console.WriteLine("Image uri: " + image.Uri);
            Console.WriteLine("Image description: " + image.Description);
            Console.WriteLine("What does the imagga think there is:");
            foreach (var item in ImaggaApi.getImageCategories(image.Uri).Tags)
            {               
                Console.WriteLine(item);
            } 
        }
    }
}