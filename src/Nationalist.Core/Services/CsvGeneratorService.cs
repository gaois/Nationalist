using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;

namespace Nationalist.Core
{
    public class CsvGeneratorService
    {
        private readonly string _outputPath;

        public CsvGeneratorService(NationalistSettings settings)
        {
            _outputPath = settings.OutputPath;
        }

        public void WriteCsv(List<Country> countries, string locale)
        {
            Console.WriteLine("Writing CSV file…");

            var outputFile = Path.Combine(_outputPath, $"{locale}/countries.{locale}.csv");

            using (var writer = new StreamWriter(outputFile))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(countries);
            }
            
            Console.WriteLine("CSV file written!");
        }
    }
}