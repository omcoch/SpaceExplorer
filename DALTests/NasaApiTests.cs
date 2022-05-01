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
        private NasaApi NasaApi = new NasaApi();

        [TestMethod()]
        public void asteroidsTest()
        {
            List<Asteroid> asteroids =
            NasaApi.asteroids(DateTime.Parse("2020-02-20"), DateTime.Parse("2020-02-24")).ToList();
            foreach (var item in asteroids)
            {
                Console.WriteLine("astroid name: {0}", item.Name);
                Console.WriteLine("astroid id: {0}", item.Id);
                Console.WriteLine("astroid size: {0}", item.DiameterInKm);
                Console.WriteLine("astroid is dangerous: {0}", item.IsDangerous);
                Console.WriteLine("Close Approach");
                Console.WriteLine("date: {0}", item.closeApproach.Date);
                Console.WriteLine("velocity: {0}", item.closeApproach.VelocityKmPerH);
                Console.WriteLine("miss distance: {0}", item.closeApproach.MissDistanceKm);
            }
        }

        [TestMethod()]
        public void closeApproachesTest()
        {          
            foreach (var item in NasaApi.closeApproaches("54208622"))
            {
                Console.WriteLine("Close Approach");
                Console.WriteLine("date: {0}", item.Date);
                Console.WriteLine("velocity: {0}", item.VelocityKmPerH);
                Console.WriteLine("miss distance: {0}", item.MissDistanceKm);
            }
        }

        [TestMethod()]
        public void asteroidsFortodayTest()
        {
             List<Asteroid> asteroids =
            NasaApi.asteroidsFortoday(true).ToList();
            foreach (var item in asteroids)
            {
                Console.WriteLine("astroid name: {0}", item.Name);
                Console.WriteLine("astroid id: {0}", item.Id);
                Console.WriteLine("astroid size: {0}", item.DiameterInKm);
                Console.WriteLine("astroid is dangerous: {0}", item.IsDangerous);
                Console.WriteLine("Close Approach");
                Console.WriteLine("date: {0}", item.closeApproach.Date);
                Console.WriteLine("velocity: {0}", item.closeApproach.VelocityKmPerH);
                Console.WriteLine("miss distance: {0}", item.closeApproach.MissDistanceKm);
            }
        }

        [TestMethod()]
        public void imageVideoSearchTest()
        {
            List<Media> images = NasaApi.imageVideoSearch("Mars").ToList();
            int i = 1;
            foreach (var item in images)
            {
                Console.WriteLine("image number {0}:", i++);
                Console.WriteLine("image title: " + item.Name);
                Console.WriteLine("image Discription: " + item.Description);
                Console.WriteLine("image uri: " + item.Uri);
            }
        }

        [TestMethod()]
        public void imageVideoSearchByIdTest()
        {
            int i = 1;
            var linkObject = NasaApi.imageVideoSearchById("as11-40-5874");
            Console.WriteLine(linkObject.objectNasaId);
            foreach (var item in linkObject.links)
            {
                Console.WriteLine("link number{0}: "+item,i++);
            }
        }
    }
}