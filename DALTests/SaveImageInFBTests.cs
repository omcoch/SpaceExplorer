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
    public class SaveImageInFBTests
    {
        [TestMethod()]
        public void stamTest()
        {
            var t = FirebaseHandle.UploadImage();
        }
    }
}