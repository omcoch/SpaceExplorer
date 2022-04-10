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
    public class PlanetReaderTests
    {
        [TestMethod()]
        public void readCsvFileTest()
        {
            PlanetReader reader = new PlanetReader();
            reader.readCsvFile();
        }
    }
}