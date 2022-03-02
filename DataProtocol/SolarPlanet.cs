using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
   public class SolarPlanet:Planet
    {
         public int YearLength { get; set; }
         public string Planet_Type { get; set; }
         public double Distance_from_Sun { get; set; }
         public int MassInZettaKg { get; set; }
         public int Diameter { get; set; }
         public int Mean_Temperature { get; set; }
         public int Moons_Number { get; set; }
         public bool hasRingSyateem { get; set; }

    }
}
