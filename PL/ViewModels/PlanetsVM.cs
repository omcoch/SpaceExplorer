using DataProtocol;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PL.ViewModels
{
    public class PlanetsVM
    {
        public List<Planet> Planets { get; private set; }

        private PlanetModel Model;

        public PlanetsVM()
        {
            Model = new PlanetModel();
            Planets = Model.GetPlanets();
        }


      

    }
}
