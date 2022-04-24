using BL;
using DataProtocol;
using System;
using System.Collections.Generic;

namespace PL.Models
{
    public class PlanetModel
    {
        private PlanetFinder BL;
        private List<Planet> planets;

        public PlanetModel()
        {
            BL = new PlanetFinder();
        }


        // We don't want let the user the ability to change this list of data
        public List<Planet> GetPlanets()
        {
            if (planets != null)
                return planets;

            planets = BL.GetPlanets();
            return planets;
        }
    }
}
