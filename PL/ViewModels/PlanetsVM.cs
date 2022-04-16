using DataProtocol;
using PL.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PL.ViewModels
{
    public class PlanetsVM
    {
        public ObservableCollection<Planet> Planets { get; private set; }

        private PlanetModel Model;

        public PlanetsVM()
        {
            Model = new PlanetModel();
            Planets = new ObservableCollection<Planet>(Model.GetPlanets());
            Planets.CollectionChanged += Planets_CollectionChanged;

        }

        private void Planets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

      

    }
}
