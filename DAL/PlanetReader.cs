using DataProtocol;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class PlanetReader
    {
        public List<Planet> Planets { get; set; }

        public List<Planet> GetPlanets()
        {
            return new List<Planet>
            {
                new Planet() {Id=1, Name="PlanetA"},
                new Planet() {Id=2, Name="PlanetB"}
            };
        }
    }
}
