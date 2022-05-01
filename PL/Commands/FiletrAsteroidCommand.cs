using PL.ViewModels;
using System;
using DataProtocol;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.Commands
{
    public class FiletrAsteroidCommand : CommandBase
    {
        private IAsteroidVM AsteroidVM;

        public FiletrAsteroidCommand(IAsteroidVM asteroidVM)
        {
            AsteroidVM = asteroidVM;
        }


        

        protected override void OnExecute(object parameter)
        {
            AsteroidVM.AsteroidResult.Clear();

            Asteroid asteroid = parameter as Asteroid;

            AsteroidVM.GetAsteroids(asteroid);
        }

        public override bool CanExecute(object parameter)
        { // At least one parameter is filled
            Asteroid asteroid = parameter as Asteroid;
            return AsteroidVM != null && AsteroidVM.ValidateDatesDistance() && asteroid.DiameterInKm >= 0;
        }


    }
}
