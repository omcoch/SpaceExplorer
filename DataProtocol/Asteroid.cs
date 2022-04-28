using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
  public  class Asteroid
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double DiameterInKm { get; set; }
        public bool IsDangerous { get; set; }
        public AsteroidCloseApproach closeApproach { get; set; }

    }
}
