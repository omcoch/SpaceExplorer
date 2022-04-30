using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DataProtocol;
namespace PL.Models
{
    public class TleModle
    {
        public List<TleInfo> TleSearchList { get; set; }
        private TleHandler BL;
        public TleModle()
        {
            TleSearchList = new List<TleInfo>();
            BL = new TleHandler();
        }
        public TleInfo GetInfo(int id)
        {
            return BL.GetInfoSatellite(id);
        }
        public List<TleInfo> SearchTle(string search)
        {
           TleSearchList=BL.Search(search).ToList();
           return TleSearchList;
        }
        public TlePropagate GetPropagateOfSatellite(int id)
        {
            return BL.GetTlePropagate(id);
        }
    }
}
