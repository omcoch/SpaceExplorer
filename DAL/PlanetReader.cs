using DataProtocol;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
namespace DAL
{
    public class PlanetReader
    {
        public List<Planet> Planets { get; set; }

        public List<Planet> ReadCsvFile()
        {
            string [] currentLine;
            Planet planet = new Planet();
            var Reader = new TextFieldParser(@"..\..\planets.csv");
            Reader.TextFieldType = FieldType.Delimited;
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

        public List<Planet> GetPlanets()
        {
            return new List<Planet>
            {
                new Planet() {Id=1, Name="PlanetA"},
                new Planet() {Id=2, Name="PlanetB"}
            };
        }
    }
}
