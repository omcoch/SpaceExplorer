using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PL.Views
{
    /// <summary>
    /// Interaction logic for DailyImageUserControl.xaml
    /// </summary>
    public partial class DailyImageUserControl : UserControl
    {
        public ImageDetailVM CurrentVM;

        public DailyImageUserControl()
        {
            InitializeComponent();

            CurrentVM = new ImageDetailVM();
            DataContext = CurrentVM;
        }
    }
}
