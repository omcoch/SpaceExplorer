﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;

namespace DAL.Tests
{
    [TestClass()]
    public class NasaApiTests
    {
        [TestMethod()]
        public void asteroidsTest()
        {
            NasaApi nasaApi = new NasaApi(); List<Asteroid>  asteroids=
            nasaApi.asteroids(DateTime.Parse("2020-02-20"), DateTime.Parse("2020-02-24")).ToList();

        }
    }
}