using DataProtocol;
using PL.Commands;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL.ViewModels
{
    public class AsteroidVM : ViewModelBase, IAsteroidVM
    {
        private AsteroidModel Model;
        public FiletrAsteroidCommand SearchCommand { get; set; }
        public SuggestionCommand SuggestionCommand { get; set; }

        private string name;
        private string diameter;
        private bool isDangerous;


        public AsteroidVM(TextBox textBoxSuggested)
        {
            Model = new AsteroidModel();
            SearchCommand = new FiletrAsteroidCommand(this);
            SuggestionCommand = new SuggestionCommand(textBoxSuggested);
        }

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                SetProperty(ref name, value, "Name");
            }
        }

        public string Diameter
        {
            get => Model.Diameter;
            set
            {
                Model.Diameter = value;
                SetProperty(ref diameter, value, "Diameter");
            }
        }

        public bool IsDangerous
        {
            get => Model.IsDangerous;
            set
            {
                Model.IsDangerous = !Model.IsDangerous;
                SetProperty(ref isDangerous, value, "IsDangerous");
            }
        }

        public List<Asteroid> AsteroidResult { get; set; }
        public List<AsteroidCloseApproach> AsteroidCloseApproachResult { get; set; }

    }
}
