using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public class TlePropagate
    {
        string link;
        string type;
        TleInfo tle;
        string algo;
        (string referenceframe, Object3d p0,Object3d dirVector) vector;
        (double latitude, double longitude, double altitude) geodetic;

        public string Link { get => link; set => link = value; }
        public string Type { get => type; set => type = value; }
        public TleInfo Tle { get => tle; set => tle = value; }
        public string Algo { get => algo; set => algo = value; }
        public (double latitude, double longitude, double altitude) Geodetic { get => geodetic; set => geodetic = value; }
        public (string referenceframe, Object3d p0, Object3d dirVector) Vector { get => vector; set => vector = value; }
    }
    public class Object3d
    {
        public double x;
        public double y;
        public double z;
        public double r;
        public string unitName;
    }
}
