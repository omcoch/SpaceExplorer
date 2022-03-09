using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            NasaApi nasaApi = new NasaApi(); List<Asteroid> asteroids =
            nasaApi.asteroids(DateTime.Parse("2020-02-20"), DateTime.Parse("2020-02-24")).ToList();
            foreach (var item in asteroids)
            {
                Console.WriteLine("astroid name: {0}", item.Name);
                Console.WriteLine("astroid id: {0}", item.Id);
                Console.WriteLine("astroid size: {0}", item.DiameterInKm);
                Console.WriteLine("astroid is dangerous: {0}", item.isDangerous);
                Console.WriteLine("Close Approach");
                Console.WriteLine("date: {0}", item.closeApproach.Date);
                Console.WriteLine("velocity: {0}", item.closeApproach.velocityKmPerH);
                Console.WriteLine("miss distance: {0}", item.closeApproach.missDistanceKm);
            }
        }

        [TestMethod()]
        public void closeApproachesTest()
        {
            NasaApi nasaApi = new NasaApi();
            foreach (var item in nasaApi.closeApproaches(54208622))
            {
                Console.WriteLine("Close Approach");
                Console.WriteLine("date: {0}", item.Date);
                Console.WriteLine("velocity: {0}", item.velocityKmPerH);
                Console.WriteLine("miss distance: {0}", item.missDistanceKm);
            }
        }

        [TestMethod()]
        public void asteroidsFortodayTest()
        {
            NasaApi nasaApi = new NasaApi(); List<Asteroid> asteroids =
          nasaApi.asteroidsFortoday(true).ToList();
            foreach (var item in asteroids)
            {
                Console.WriteLine("astroid name: {0}", item.Name);
                Console.WriteLine("astroid id: {0}", item.Id);
                Console.WriteLine("astroid size: {0}", item.DiameterInKm);
                Console.WriteLine("astroid is dangerous: {0}", item.isDangerous);
                Console.WriteLine("Close Approach");
                Console.WriteLine("date: {0}", item.closeApproach.Date);
                Console.WriteLine("velocity: {0}", item.closeApproach.velocityKmPerH);
                Console.WriteLine("miss distance: {0}", item.closeApproach.missDistanceKm);
            }
        }
    }
}