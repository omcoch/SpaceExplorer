using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            ImaggaApi.getImageTags("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg");
        }
    }
}