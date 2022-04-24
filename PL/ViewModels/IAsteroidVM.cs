using DataProtocol;
using System.Collections.Generic;

namespace PL.ViewModels
{
    public interface IAsteroidVM
    {
        string Diameter { get; set; }
        bool IsDangerous { get; set; }
        string Name { get; set; }

        List<Asteroid> AsteroidResult { get; set; }
        List<AsteroidCloseApproach> AsteroidCloseApproachResult { get; set; }
    }
}