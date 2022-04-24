using DataProtocol;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PL.ViewModels
{
    public class SearchVM : ViewModelBase
    {

        private SearchModel Model;
        private string searchInput;

        public SearchVM()
        {
            Model = new SearchModel();
        }

        public string SearchInput
        {
            get { return Model.SearchInput; }
            set 
            {
                Model.SearchInput = value;
                SetProperty(ref searchInput, value, "SearchInput");
            }
        }





    }
}
