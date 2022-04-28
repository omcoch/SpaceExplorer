﻿using DataProtocol;
using PL.Commands;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL.ViewModels
{
    public class AsteroidVM : ViewModelBase, IAsteroidVM
    {
        public AsteroidModel Model;

        public FiletrAsteroidCommand FiletrAsteroidCommand { get; set; }

        public SuggestionCommand SuggestionCommand { get; set; }

        public ObservableCollection<Asteroid> AsteroidResult { get; set; }

        private DateTime startDate;
        public DateTime StartDate
        {
            get => Model.StartDate;
            set
            {
                Model.StartDate = value;
                SetProperty(ref startDate, value, "StartDate");
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get => Model.EndDate;
            set
            {
                Model.EndDate = value;
                SetProperty(ref endDate, value, "EndDate");
            }
        }

        public AsteroidVM()
        {
            Model = new AsteroidModel();
            AsteroidResult = new ObservableCollection<Asteroid>();
            FiletrAsteroidCommand = new FiletrAsteroidCommand(this);
            AsteroidResult.CollectionChanged += AsteroidResult_CollectionChanged;
        }

        private void AsteroidResult_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newData = e.NewItems[0] as Asteroid;
                if (newData != null)
                    Model.AsteroidResult.Add(newData);
            }
        }

        public void GetAsteroids(Asteroid asteroid)
        {
            Model.GetAsteroids(StartDate, EndDate, asteroid.IsDangerous, asteroid.DiameterInKm).ToList()
                .ForEach(a => AsteroidResult.Add(a));
        }
    }
}
