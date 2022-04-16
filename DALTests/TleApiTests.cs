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
    public class TleApiTests
    {
        [TestMethod()]
        public void getTleTest()
        {
            TleApi tleApi = new TleApi();
            int i = 1, j = 0;
            foreach (var item in tleApi.getTleCollection())
            {
                Console.WriteLine("Tle Object Number {0}:", i++);
                Console.WriteLine("id: {0}", item.Id);
                Console.WriteLine("date: {0}", item.Date);
                if (item.Date == DateTime.MinValue)
                    j++;
            }
            Console.WriteLine("there was {0} mistakes", j);
        }

        [TestMethod()]
        public void GetTlePropagateTest()
        {
            TleApi tleApi = new TleApi();
            tleApi.GetTlePropagate(43638);
        }
    }
}