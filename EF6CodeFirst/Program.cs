using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.LocalDB;
using DataProtocol;

namespace EF6CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AddMedia(description: "example", name: "Ex", title: "title", uri: "http:dvfdfde");
            AddSearchHistory("England");

        }

        static void UpdateMedia(string name, string title, string description, string uri)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var media = new Media()
                {
                    Name = name,
                    Title = title,
                    Description = description,
                    Uri = uri
                };

                //ctx.Objects.(media);
                
                //ctx.SaveChanges();

            }

        }

        static Media GetMedia(int id)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var query = from m in ctx.MediaObjects
                            where m.MediaID == id
                            select m;

                return query.First();
            }

        }

        static void AddMedia(string name, string title, string description, string uri)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var media = new Media()
                {
                    Name = name,
                    Title = title,
                    Description = description,
                    Uri = uri,
                    Day = DateTime.Now
                };

                ctx.MediaObjects.Add(media);
                ctx.SaveChanges();

            }
        }

        void AddMediaExample(string name, string title, string description, string uri)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var media = new Media()
                {
                    Description = "Incredible Image",
                    Name = "someFile",
                    Title = "Example Image",
                    Uri = "gs://spaceexplorer-f675f.appspot.com/DailyImage/someFile.jpg"
                };

                ctx.MediaObjects.Add(media);
                ctx.SaveChanges();

            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        ///////////////////////// SearchHistory //////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////


        static void AddSearchHistory(string term)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var s = new SearchHistory()
                {
                    SearchTerm = term
                };

                ctx.SearchHistoryObjects.Add(s);
                ctx.SaveChanges();

            }
        }
    }
}
