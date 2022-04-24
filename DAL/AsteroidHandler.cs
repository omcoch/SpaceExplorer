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

        public IEnumerable<Asteroid> GetAsteroids(DateTime startDate, DateTime endDate)
        {
            return NasaApi.asteroids(startDate, endDate);
        }

        public IEnumerable<AsteroidCloseApproach> GetAsteroidById(int id)
        {
            return NasaApi.closeApproaches(id);
        }

        public IEnumerable<AsteroidCloseApproach> GetAsteroidByName(string name)
        {
            // todo: fetch data from local db?
            throw new NotImplementedException();
        }

        public IEnumerable<Asteroid> GetAsteroidForToday(bool IsDangerous, double DiameterInKm)
        {
            return NasaApi.asteroidsFortoday(IsDangerous,DiameterInKm);
        }

    }
}
