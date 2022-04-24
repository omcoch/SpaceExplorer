using DataProtocol;
using System;
using System.Collections.ObjectModel;

namespace PL.ViewModels
{
    public interface ISearchVM
    {
        ObservableCollection<Media> SearchResult { get; set; }
        Action<string> Callback { get; }

    }
}   