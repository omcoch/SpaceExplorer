using DataProtocol;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Linq;

namespace DAL
{
    public class PlanetReader
    {
        public List<Planet> Planets { get; set; }

        public List<Planet> ReadCsvPlanets()
        {
            try
            {
                StreamReader reader = new StreamReader(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..\..\DAL\LocalDB\planets.csv"));
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<Planet>();
                        return new List<Planet>(records);
                    }
                }
            }
            catch
            {
                //throw new Exception(ex.Message);
                return GetDefaultPlanet();
            }
        }


        // Default values setter
        public List<Planet> GetDefaultPlanet()
        {
            return new List<Planet>
            {
                new Planet() {PlanetName="Default Planet"},
            };
        }

        // Old function
        public List<Planet> ReadCsvFile()
        {
            string[] currentLine;
            Planet planet = new Planet();
            var Reader = new TextFieldParser(@"..\..\LocalDB\planets.csv");

            Reader.TextFieldType = FieldType.Delimited;
            Reader.SetDelimiters(",");
            while (!Reader.EndOfData)
            {
                currentLine = Reader.ReadFields();
                foreach (var row in currentLine)
                {

                }

            }
            return null;
        }
    }
}
