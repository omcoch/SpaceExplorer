using DataProtocol;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PL.ViewModels
{
    public interface IAsteroidVM
    {
        ObservableCollection<Asteroid> AsteroidResult { get; set; }

        void GetAsteroids(Asteroid asteroid);
    }
}