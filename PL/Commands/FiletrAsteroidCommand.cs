using PL.ViewModels;
using System;
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
            /.
            /*
             * to Do:
             * needs to do one of three options:
             * Get Today Astroids: new BL.AsteroidFinder().GetAsteroids(today , null, parameter[is Dangers], parameter[diameter])
             * Get Week  Astroids: new BL.AsteroidFinder().GetAsteroids(StartDate,EndDate, parameter[is Dangers], parameter[diameter]);
             * Get Asrtoid data:   new BL.AsteroidFinder().GetAsteroid(parameter[id])
             * 
             */
        }

        public override bool CanExecute(object parameter)
        { // At least one parameter is filled
            return AsteroidVM != null && 
                (AsteroidVM.IsDangerous != false || AsteroidVM.Diameter != null || AsteroidVM.Name != null);
        }


    }
}
