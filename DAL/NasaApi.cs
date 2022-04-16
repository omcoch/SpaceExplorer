using System;
using System.Collections.Generic;
using DataProtocol;
using Newtonsoft.Json;

namespace DAL
{
    public static class NasaApi
    {
        private static string dateFormat = "yyyy-MM-dd";
        public static string ApiKey = "3c9WFghad2gXj8beUc9TtwjdjRITVH4rFPZ2F5Oe";

        public static Media GetDailyImage(DateTime date)
        {
            Media result = new Media();
            var dict = MakeDateReq(date);
            
            result.UniqueName = "NasaDailyImageFor" + date.ToString(dateFormat);
            if(dict.ContainsKey("url"))
               result.Uri = dict["url"];
            if (dict.ContainsKey("explanation"))
                result.Description = dict["explanation"];
            if (dict.ContainsKey("title"))
                result.Title = dict["title"];
            return result;
        }

        public static IEnumerable<Asteroid> asteroids(DateTime StartDate, DateTime EndDate)
        {
            List<Asteroid> result = new List<Asteroid>();
            TimeSpan time = StartDate - EndDate;
            Asteroid asteroid = new Asteroid();
            if (time.TotalDays > 7)
                throw new ArgumentException("Between the dates there must be a difference of less than or equal to seven days.");
            string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + StartDate.ToString(dateFormat) + "&end_date=" + EndDate.ToString(dateFormat) + "&api_key=" + ApiKey;
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
                        asteroid.Name = (string)jToken["name"];
                        asteroid.Id = (int)jToken["id"];
                        asteroid.DiameterInKm = ((double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_min"]+ (double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_max"])/2;
                        asteroid.isDangerous = (bool)jToken["is_potentially_hazardous_asteroid"];
                        asteroid.closeApproach = new AsteroidCloseApproach();
                        asteroid.closeApproach.Date = DateTime.Parse((string)jToken["close_approach_data"].First["close_approach_date"]);
                        asteroid.closeApproach.missDistanceKm= (double)jToken["close_approach_data"].First["miss_distance"]["kilometers"];
                        asteroid.closeApproach.velocityKmPerH = (double)jToken["close_approach_data"].First["relative_velocity"]["kilometers_per_hour"];
                        result.Add(asteroid);
                    }                 
                }
            }
            return result;
        }

        public static IEnumerable<Asteroid> asteroidsFortoday(bool isDangerous=false,double DiameterInKm=0)
        {
            List<Asteroid> result = new List<Asteroid>();
            Asteroid asteroid = new Asteroid();
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
                        if (!isDangerous || (bool)jToken["is_potentially_hazardous_asteroid"])
                        {
                            asteroid.Name = (string)jToken["name"];
                            asteroid.Id = (int)jToken["id"];
                            asteroid.DiameterInKm = ((double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_min"] + (double)jToken["estimated_diameter"]["kilometers"]["estimated_diameter_max"]) / 2;
                            asteroid.isDangerous = (bool)jToken["is_potentially_hazardous_asteroid"];
                            asteroid.closeApproach = new AsteroidCloseApproach();
                            asteroid.closeApproach.Date = DateTime.Parse((string)jToken["close_approach_data"].First["close_approach_date"]);
                            asteroid.closeApproach.missDistanceKm = (double)jToken["close_approach_data"].First["miss_distance"]["kilometers"];
                            asteroid.closeApproach.velocityKmPerH = (double)jToken["close_approach_data"].First["relative_velocity"]["kilometers_per_hour"];
                            result.Add(asteroid);
                        }
                    }
                }
            }
            result.RemoveAll(x => x.DiameterInKm < DiameterInKm);
            return result;
        }

        public static IEnumerable<AsteroidCloseApproach> closeApproaches(int AsteriodId)
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
                    closeApproach.velocityKmPerH = (double)item["relative_velocity"]["kilometers_per_hour"];
                    closeApproach.missDistanceKm = (double)item["miss_distance"]["kilometers"];
                    result.Add(closeApproach);
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public static NasaLinksForObject imageVideoSearchById(string nasaID = "")
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
                        links.Add((string)item["href"]);
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
        public static IEnumerable<Media> imageVideoSearch(string WhatToSearch="")
        {
            try
            {
                List<Media> result = new List<Media>();
                string basicUri = "https://images-api.nasa.gov/";
                var responseStr = "";
                if (WhatToSearch.Length != 0 )
                {
                    responseStr = MakeHttpReq.Get(basicUri + String.Format("search?q={0}", WhatToSearch));
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
                    Media media;
                    foreach (var item in (dict["collection"] as Newtonsoft.Json.Linq.JObject)["items"].Children())
                    {
                        media = new Media();
                        media.UniqueName = (string)item["data"].First["title"];
                        media.Description = (string)item["data"].First["description"];
                        media.Title = media.UniqueName;
                        media.Uri = (string)item["links"].First.First;
                        result.Add(media);
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static Dictionary<string, string> MakeDateReq(DateTime date)
        {            
            string url = String.Format("https://api.nasa.gov/planetary/apod?api_key={0}&date={1}", ApiKey, date.ToString(dateFormat));
            var responseStr = MakeHttpReq.Get(url);
            while (responseStr == null) // an error because time differences with the United States
            {
                date = date.AddDays(-1);
                responseStr = MakeHttpReq.Get(String.Format("https://api.nasa.gov/planetary/apod?api_key={0}&date={1}", ApiKey, date.ToString(dateFormat)));
            }
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
        }
         

    }
}
