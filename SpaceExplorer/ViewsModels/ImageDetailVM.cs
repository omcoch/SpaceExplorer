using SpaceExplorer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorer.ViewsModels
{
    public class ImageDetailVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DailyImageModel Model;

        public ImageDetailVM()
        {
            Model = new DailyImageModel();

        }

        public string ImageUri
        {
            get { return Model.ImageUri; }
            set
            {
                Model.ImageUri = value;
                if (null != PropertyChanged)
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageUri"));
            }
        }

        public string ImageDescription
        {
            get { return Model.ImageDescription; }
            set
            {
                Model.ImageDescription = value;
                if (null != PropertyChanged) 
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageDescription"));
            }
        }

        public string ImageTitle
        {
            get { return Model.ImageTitle; }
            set
            {
                Model.ImageTitle = value;
                if (null != PropertyChanged)
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageTitle"));
            }
        }

    }
}
