using DataProtocol;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class AsteroidModel
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public List<Asteroid> AsteroidResult { get; set; }
        public List<AsteroidCloseApproach> AsteroidCloseApproachResult { get; set; }

        private AsteroidFinder BL;

        public AsteroidModel()
        {
            AsteroidResult = new List<Asteroid>();  
            AsteroidCloseApproachResult = new List<AsteroidCloseApproach>();
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            BL = new AsteroidFinder();
        }

        /*
        * Filtering Options:
        * needs to do one of three options:
        * Get Today Astroids: new BL.AsteroidFinder().GetAsteroids(today , null, parameter[is Dangers], parameter[diameter])
        * Get Week  Astroids: new BL.AsteroidFinder().GetAsteroids(StartDate,EndDate, parameter[is Dangers], parameter[diameter]);
        * Get Asrtoid data:   new BL.AsteroidFinder().GetAsteroid(parameter[id])
        * 
        */

        public IEnumerable<AsteroidCloseApproach> GetAsteroid(string id)
        {
            return BL.GetAsteroid(id).ToList();
        }

        public IEnumerable<Asteroid> GetAsteroids(DateTime StartDate, DateTime EndDate, bool IsDangerous = false, double DiameterInKm = 0)
        {
            return BL.GetAsteroids(StartDate, EndDate, IsDangerous, DiameterInKm).ToList();
        }

        public IEnumerable<Asteroid> GetAsteroidsForToday(bool IsDangerous = false, double DiameterInKm = 0)
        {
            return BL.GetAsteroids(DateTime.Today, DateTime.Today, IsDangerous, DiameterInKm).ToList();
        }


    }
}
