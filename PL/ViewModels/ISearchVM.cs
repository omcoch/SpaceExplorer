using DataProtocol;
using System;
using System.Collections.ObjectModel;

namespace PL.ViewModels
{
    public interface ISearchVM
    {
        bool SearchByName(string input);
    }
}   