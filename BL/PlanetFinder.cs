using DAL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PlanetFinder
    {
        private PlanetReader DAL;

        public PlanetFinder()
        {
            DAL = new PlanetReader();
        }

        public List<Planet> GetPlanets()
        {
            return DAL.ReadCsvPlanets();
        }

        public List<Planet> GetPlanet(string name)
        {
            // Todo: the BL should create an empty list and send it to the DAL, and the DAL would fill it out and send it back to the BL

            return (from p in DAL.Planets
                    where p.PlanetName == name
                    select p)
                    .ToList();
        }
    }
}
