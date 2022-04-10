using DataProtocol;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
namespace DAL
{
    public class PlanetReader
    {
        public List<Planet> Planets { get; set; }
        public List<Planet> readCsvFile()
        {
            string [] currentLine;
            Planet planet = new Planet();
            var Reader = new TextFieldParser(@"..\..\planets.csv");
            Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            Reader.SetDelimiters(",");
            while(!Reader.EndOfData)
            {
                currentLine = Reader.ReadFields();
                foreach (var item in currentLine)
                {
                    
                }
            }
            return null;
        }
    }
}
