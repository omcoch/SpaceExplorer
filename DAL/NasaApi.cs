using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DataProtocol;
using Newtonsoft.Json;

namespace DAL
{
    public class NasaApi
    {
        private string DateFormat = "yyyy-MM-dd";
        public string ApiKey = "3c9WFghad2gXj8beUc9TtwjdjRITVH4rFPZ2F5Oe";


        public Media GetDailyImage(DateTime date)
        {
            Media result = new Media();
            var dict = MakeDateReq(date);
            
            if(dict.ContainsKey("url"))
               result.Uri = dict["url"];
            if (dict.ContainsKey("explanation"))
                result.Description = dict["explanation"];
            if (dict.ContainsKey("title"))
                result.Title = dict["title"];
            if (dict.ContainsKey("date"))
                result.Day = DateTime.Parse(dict["date"]);
            result.NasaId = "0";
            return result;
        }

        public IEnumerable<Asteroid> asteroids(DateTime StartDate, DateTime EndDate)
        {
            List<Asteroid> result = new List<Asteroid>();
            TimeSpan time = StartDate - EndDate;
            Asteroid asteroid;
            if (time.TotalDays > 7)
                throw new ArgumentException("Between the dates there must be a difference of less than or equal to seven days.");
            string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + StartDate.ToString(DateFormat) + "&end_date=" + EndDate.ToString(DateFormat) + "&api_key=" + ApiKey;
            var responseStr = MakeHttpReq.Get(url);
            var dict = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseStr);
            var temp = dict["near_earth_objects"];
            for (int i = 0; i < (temp as Newtonsoft.Json.Linq.JObject).Count; i++)
            {
                var dataForDate = (temp as Newtonsoft.Json.Linq.JObject).First;
                foreach (var item in dataForDate.Children())
                {
                    foreach (var jToken in item)
                    {
                        asteroid = new Asteroid();
                        asteroid.Name = (string)jToken["name"];
                        asteroid.Id = (string)jToken["id"];
                        asteroid.DiameterInKm = ((double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_min"]+ (double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_max"])/2;
                        asteroid.IsDangerous = (bool)jToken["is_potentially_hazardous_asteroid"];
                        asteroid.closeApproach = new AsteroidCloseApproach();
                        asteroid.closeApproach.Date = DateTime.Parse((string)jToken["close_approach_data"].First["close_approach_date"]);
                        asteroid.closeApproach.MissDistanceKm= (double)jToken["close_approach_data"].First["miss_distance"]["kilometers"];
                        asteroid.closeApproach.VelocityKmPerH = (double)jToken["close_approach_data"].First["relative_velocity"]["kilometers_per_hour"];
                        result.Add(asteroid);
                    }                 
                }
            }
            return result;
        }

        public IEnumerable<Asteroid> asteroidsFortoday(bool IsDangerous=false, double DiameterInKm=0)
        {
            List<Asteroid> result = new List<Asteroid>();
            Asteroid asteroid;
            string url = "https://api.nasa.gov/neo/rest/v1/feed/today?" + "detailed=true&"+ "api_key=" + ApiKey;
            var responseStr = MakeHttpReq.Get(url);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
            var temp = dict["near_earth_objects"];
            for (int i = 0; i < (temp as Newtonsoft.Json.Linq.JObject).Count; i++)
            {
                var dataForDate = (temp as Newtonsoft.Json.Linq.JObject).First;
                foreach (var item in dataForDate.Children())
                {
                    foreach (var jToken in item)
                    {
                        if (!IsDangerous || (bool)jToken["is_potentially_hazardous_asteroid"])
                        {
                            asteroid = new Asteroid();
                            asteroid.Name = (string)jToken["name"];
                            asteroid.Id = (string)jToken["id"];
                            asteroid.DiameterInKm = ((double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_min"] + (double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_max"]) / 2;
                            asteroid.IsDangerous = (bool)jToken["is_potentially_hazardous_asteroid"];
                            asteroid.closeApproach = new AsteroidCloseApproach();
                            asteroid.closeApproach.Date = DateTime.Parse((string)jToken["close_approach_data"].First["close_approach_date"]);
                            asteroid.closeApproach.MissDistanceKm = (double)jToken["close_approach_data"].First["miss_distance"]["kilometers"];
                            asteroid.closeApproach.VelocityKmPerH = (double)jToken["close_approach_data"].First["relative_velocity"]["kilometers_per_hour"];
                            result.Add(asteroid);
                        }
                    }
                }
            }
            result.RemoveAll(x => x.DiameterInKm < DiameterInKm);
            return result;
        }

        public IEnumerable<AsteroidCloseApproach> closeApproaches(string AsteriodId)
        {
            try
            {
                List<AsteroidCloseApproach> result = new List<AsteroidCloseApproach>();
                AsteroidCloseApproach closeApproach;
                string url = "https://api.nasa.gov/neo/rest/v1/neo/" + AsteriodId + "?api_key=" + ApiKey;
                var responseStr = MakeHttpReq.Get(url);
                var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
                var listCloseApproach = dict["close_approach_data"];
                foreach (var item in (listCloseApproach as Newtonsoft.Json.Linq.JArray).Children())
                {
                    closeApproach = new AsteroidCloseApproach();
                    closeApproach.Date = DateTime.Parse((string)item["close_approach_date_full"]);
                    closeApproach.VelocityKmPerH = (double)item["relative_velocity"]["kilometers_per_hour"];
                    closeApproach.MissDistanceKm = (double)item["miss_distance"]["kilometers"];
                    result.Add(closeApproach);
                }
                return result;

            }
            catch
            {
                return null;
            }
            
        }
        public NasaLinksForObject imageVideoSearchById(string nasaID = "")
        {
            try
            {
                NasaLinksForObject linkObject = new NasaLinksForObject();
                string basicUri = "https://images-api.nasa.gov/";
                var responseStr = "";
                if (nasaID.Length != 0)
                {
                    responseStr = MakeHttpReq.Get(basicUri + String.Format("asset/{0}", nasaID));
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);                  
                    linkObject.objectNasaId = nasaID;
                    List<string> links = new List<string>();
                    foreach (var item in (dict["collection"] as Newtonsoft.Json.Linq.JObject)["items"].Children())
                    {
                        try
                        {
                            links.Add((string)item["href"]);
                        }
                        catch (Exception) {}
                    }
                    linkObject.links = links;
                }
                return linkObject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Media> imageVideoSearch(string WhatToSearch="")
        {
            try
            {
                string basicUri = "https://images-api.nasa.gov/";
                var responseStr = "";
                if (WhatToSearch.Length != 0 )
                {
                    responseStr = MakeHttpReq.Get(basicUri + String.Format("search?q={0}", WhatToSearch));
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
                    return (from item in (dict["collection"] as Newtonsoft.Json.Linq.JObject)["items"].Children()
                            where item["links"] != null && item["data"] != null
                             select new Media()
                             {
                                 Name = (string)item["data"].First["title"],
                                 Title = (string)item["data"].First["title"],
                                 Description = (string)item["data"].First["description"],
                                 Uri = (string)item["links"].First.First,
                                 NasaId = (string)item["data"].First["nasa_id"],
                                 Day = DateTime.Parse(DateTime.Today.ToString(), new CultureInfo("en-US"))
                             }).ToList();
                }
                return Enumerable.Empty<Media>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Dictionary<string, string> MakeDateReq(DateTime date)
        {            
            string url = String.Format("https://api.nasa.gov/planetary/apod?api_key={0}&date={1}", ApiKey, date.ToString(DateFormat));
            var responseStr = MakeHttpReq.Get(url);
            while (responseStr == null) // an error because time differences with the United States
            {
                date = date.AddDays(-1);
                responseStr = MakeHttpReq.Get(String.Format("https://api.nasa.gov/planetary/apod?api_key={0}&date={1}", ApiKey, date.ToString(DateFormat)));
            }
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
        }
         

    }
}
