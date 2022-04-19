using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PL.Views
{
    /// <summary>
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        SearchVM currentVM = new SearchVM();

        public SearchUserControl()
        {
            InitializeComponent();
            DataContext = currentVM;
            SuggestionBox.TextChanged += currentVM.SuggestionBoxOnTextChanged;
        }

        
    }
}
