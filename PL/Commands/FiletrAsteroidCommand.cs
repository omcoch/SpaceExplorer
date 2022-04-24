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
            if (AsteroidVM.Name != null)
                AsteroidVM.AsteroidCloseApproach = new BL.AsteroidFinder().GetAsteroidByName(AsteroidVM.Name).ToList();
            else if (AsteroidVM.Diameter != null)
                AsteroidVM.SearchResult = (List<DataProtocol.Asteroid>)new BL.AsteroidFinder().GetAsteroidForToday(AsteroidVM.IsDangerous, double.Parse(AsteroidVM.Diameter));
        }

        public override bool CanExecute(object parameter)
        { // At least one parameter is filled
            return AsteroidVM != null && 
                (AsteroidVM.IsDangerous != false || AsteroidVM.Diameter != null || AsteroidVM.Name != null);
        }


    }
}
