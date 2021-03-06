using BL;
using DataProtocol;
using PL.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace PL.Commands
{
    public class SearchCommand : CommandBase
    {
        private ISearchVM SearchVM;
        

        public SearchCommand(ISearchVM searchVM)
        {
            SearchVM = searchVM;
            
        }

        public override bool CanExecute(object SearchInput)
        {
            var input = SearchInput as string;
            return input != null && input.Trim().Length > 0;
        }

        protected override void OnExecute(object SearchInput)
        {
            var input = SearchInput as string;

            SearchVM.SearchByName(input);

        }


    }
}