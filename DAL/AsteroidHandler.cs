using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;

namespace DAL
{
    public class AsteroidHandler
    {
        private NasaApi NasaApi = new NasaApi();

        public IEnumerable<Asteroid> GetAsteroids(DateTime startDate, DateTime endDate,bool IsDangerous= false, double DiameterInKm = 0)
        {
            if (IsDangerous)
                return NasaApi.asteroids(startDate, endDate).Where(A => A.IsDangerous == true && A.DiameterInKm > DiameterInKm);
            else return NasaApi.asteroids(startDate, endDate).Where(A => A.DiameterInKm > DiameterInKm);
        }

        public IEnumerable<AsteroidCloseApproach> GetAsteroidById(string id)
        {
            return NasaApi.closeApproaches(id);
        }

        public IEnumerable<Asteroid> GetAsteroidsForToday( bool IsDangerous = false, double DiameterInKm = 0)
        {
            return NasaApi.asteroidsFortoday(IsDangerous, DiameterInKm);
        }

    }
}
