using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;
using Newtonsoft.Json;


namespace DAL
{
   public class TleApi
    {
        private bool checkParmeters(string sort, int page, int pageSize)
        {
            List<string> sortOptions =new List<string> { "id", "name" ,"popularity" ,"inclination" ,"eccentricity" ,"period" };
            if (page < 1) return false;
            if (!sortOptions.Contains(sort)) return false;
            if(pageSize>100 && pageSize<1) return false;
            return true;
        }
        public IEnumerable<TleInfo> getTleCollection(string search="",string sort= "popularity", bool sort_dir=true,int page=1,int pageSize=100)
        {
            List<TleInfo> result = new List<TleInfo>();
            if (!checkParmeters(sort, page, pageSize)) return null;
             string uri = string.Format("https://tle.ivanstanojevic.me/api/tle/?search={0}&sort={1}&sort-dir={2}&page={3}&page-size={4}",search,sort,sort_dir? "desc" : "asc",page,pageSize);
            string responseStr = MakeHttpReq.Get(uri);
            if (responseStr == null) return null;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
            if((long)dict["totalItems"]!=0)
            {
                TleInfo tleInfo; 
                foreach (var item in (dict["member"] as Newtonsoft.Json.Linq.JArray))
                {
                    tleInfo = new TleInfo();
                    tleInfo.Link = (string)item["@id"];
                    tleInfo.Name = (string)item["name"];
                    tleInfo.Type= (string)item["@type"];
                    tleInfo.Id= (int)item["satelliteId"];
                    tleInfo.Line1 = (string)item["line1"];
                    tleInfo.Line2 = (string)item["line2"];
                    DateTime dateTime;
                    DateTime.TryParse((string)item["date"],out dateTime);
                    tleInfo.Date = dateTime;
                    result.Add(tleInfo);
                }
            }
            return result;
        }
        public TleInfo GetTleInfo(int id)
        {
            TleInfo tleInfo = new TleInfo();
            string uri = string.Format("https://tle.ivanstanojevic.me/api/tle/{0}", id);
            string responseStr = MakeHttpReq.Get(uri);
            if (responseStr == null) return tleInfo;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);     
            tleInfo.Link = (string)dict["@id"];
            tleInfo.Name = (string)dict["name"];
            tleInfo.Type = (string)dict["@type"];
            tleInfo.Id = (int)dict["satelliteId"];
            tleInfo.Line1 = (string)dict["line1"];
            tleInfo.Line2 = (string)dict["line2"];
            DateTime dateTime;
            DateTime.TryParse((string)dict["date"], out dateTime);
            tleInfo.Date = dateTime;
            return tleInfo;
        }
        public TlePropagate GetTlePropagate(int id,string date="")
        {
            TlePropagate result = new TlePropagate();
            DateTime Date;
            DateTime.TryParse(date, out Date);
            string uri = String.Format("https://tle.ivanstanojevic.me/api/tle/{0}/propagate{1}",id, date != "" ?string.Format("?date={0}",Date.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK")):"");
            string responseStr=MakeHttpReq.Get(uri);
            if (responseStr != null)
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
                result.Link = (string)dict["@id"];
                result.Algo = (string)dict["algorithm"];
                string rf=(string)(dict["vector"] as Newtonsoft.Json.Linq.JObject)["reference_frame"];
                Object3d p0 = new Object3d();
                Object3d dir = new Object3d();
                var indexer1 = (dict["vector"] as Newtonsoft.Json.Linq.JObject)["position"];
                p0.x= (double)indexer1["x"];
                p0.y= (double)indexer1["y"];
                p0.z= (double)indexer1["z"];
                p0.r = (double)indexer1["r"];
                p0.unitName=(string)indexer1["unit"];
                var indexer2 = (dict["vector"] as Newtonsoft.Json.Linq.JObject)["velocity"];
                dir.x = (double)indexer2["x"];
                dir.y = (double)indexer2["y"];
                dir.z = (double)indexer2["z"];
                dir.r = (double)indexer2["r"];
                dir.unitName= (string)indexer2["unit"];
                result.Vector = (rf,p0,dir);
                var indexer3 = dict["geodetic"] as Newtonsoft.Json.Linq.JObject;
                result.Geodetic = ((double)indexer3["latitude"], (double)indexer3["longitude"], (double)indexer3["altitude"]);
                var indexer4= dict["tle"] as Newtonsoft.Json.Linq.JObject;
                result.Tle = new TleInfo();
                result.Tle.Link = (string)indexer4["@id"];
                result.Tle.Name = (string)indexer4["name"];
                result.Tle.Type = (string)indexer4["@type"];
                result.Tle.Id = (int)indexer4["satelliteId"];
                result.Tle.Line1 = (string)indexer4["line1"];
                result.Tle.Line2 = (string)indexer4["line2"];
                return result;
            }
            else return result;
        }
    }
}
