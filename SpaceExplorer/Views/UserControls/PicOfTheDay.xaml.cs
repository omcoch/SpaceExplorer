using DataProtocol;
using SpaceExplorer.APIs;
using SpaceExplorer.ViewsModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Threading;


namespace SpaceExplorer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PicOfTheDay.xaml
    /// </summary>
    public partial class PicOfTheDay : UserControl
    {

        public ImageDetailVM CurrentVM; 

        private DateTime Today = DateTime.Now;


        private void Update(object sender, EventArgs e)
        {
            if (DateTime.Now.Day != Today.Day)
            {
                Today = DateTime.Now;

                // get here the nasa api through BL...

            }
        }

        public PicOfTheDay()
        {
            InitializeComponent();
            CurrentVM = new ImageDetailVM();
            DataContext = CurrentVM;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Update;
            timer.Start();
        }

    }
}
