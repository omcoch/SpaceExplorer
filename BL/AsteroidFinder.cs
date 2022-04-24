using DAL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class AsteroidFinder
    {
        private AsteroidHandler DAL;


        public AsteroidFinder()
        {
            DAL = new AsteroidHandler();
        }

        

        public IEnumerable<AsteroidCloseApproach> GetAsteroid(string id)
        {
            int intId;
            if (int.TryParse((id ?? "").ToString(), out intId))
                return DAL.GetAsteroidById(intId);

            return GetAsteroidByName(id);
        }

        public IEnumerable<AsteroidCloseApproach> GetAsteroidByName(string name)
        {
            return DAL.GetAsteroidByName(name);
        }

        public IEnumerable<Asteroid> GetAsteroidForToday(bool IsDangerous, double DiameterInKm)
        {
            return DAL.GetAsteroidForToday(IsDangerous, DiameterInKm);
        }

    }
}
