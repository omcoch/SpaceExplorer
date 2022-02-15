using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceExplorer.UserControls
{
    /// <summary>
    /// Interaction logic for PicOfTheDay.xaml
    /// </summary>
    public partial class PicOfTheDay : UserControl
    {

        DateTime today = DateTime.Now;

        public PicOfTheDay()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Update;
            timer.Start();
        }

        void Update(object sender, EventArgs e)
        {
            if (DateTime.Now.Day != today.Day)
            {
                today = DateTime.Now;
                // nasa.getNewPicture
            }
        }
    }
}
