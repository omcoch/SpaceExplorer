using BL;
using DataProtocol;
using PL.ViewModels;
using System.Collections.Generic;

namespace PL.Commands
{
    public class SearchCommand : CommandBase
    {
        private ISearchVM SearchVM;
        private SearchMedia SearchBL;

        public SearchCommand(ISearchVM searchVM)
        {
            SearchVM = searchVM;
            SearchBL = new SearchMedia();
        }

        public override bool CanExecute(object SearchInput)
        {
            var input = SearchInput as string;
            return input != null && input.Trim().Length > 0;
        }

        protected override void OnExecute(object SearchInput)
        {
            var input = SearchInput as string;

            if (SearchVM.SearchResult == null)
                SearchVM.SearchResult = new System.Collections.ObjectModel.ObservableCollection<Media>();

            SearchVM.SearchResult.Clear();
            foreach (Media media in SearchBL.SearchByName(input))
            {
                List<string> possibleTags = SearchBL.GetTags(media);
                foreach (string word in media.Title.Split(' '))
                {
                    if (possibleTags.Contains(word))
                    {
                        SearchVM.SearchResult.Add(media);
                        break;
                    }
                }                    
            }

            SearchVM.Callback(input);

        }


    }
}