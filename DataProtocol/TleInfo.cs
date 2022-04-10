using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
   public class TleInfo
    {
        string link;
        string type;
        int id;
        string name;
        DateTime date;
        string line1;
        string line2;
        public string Type { get => type; set => type = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Link { get => link; set => link = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Line1 { get => line1; set => line1 = value; }
        public string Line2 { get => line2; set => line2 = value; }
    }
}
