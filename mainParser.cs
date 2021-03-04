using System;
using CsvHelper;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace csv2prj
{
    public static class MainParser
    {
        public static void ParseCSV(string csvFile)
        {
            List<DataObject> csvData = ReadCSV(csvFile);

            Project prj = new Project();
            
            for (int i = 0; i < csvData.Count; i++)
            {
                Task newTask = new Task();
                newTask.Name = string.Format("{0} ({1})", csvData[i].Name, csvData[i].Code);
                newTask.ID = (i + 1);
                newTask.UID = (i + 1);
                newTask.Duration = $"PT{csvData[i].Duration}H00M00S";

                prj.Tasks.Add(newTask);
            }

            SaveToXML(prj, "output-example.xml");

            Console.WriteLine($"readData.Count={csvData.Count}");
            for (int i = 0; i < csvData.Count; i++)
            {
                Console.WriteLine($"[{i}]: Name={csvData[i].Name}; Code={csvData[i].Code}; Quantity={csvData[i].Quantity};");
            }
        }

        public static List<DataObject> ReadCSV(string fileName)
        {
            List<DataObject> readData = new List<DataObject>();

            using (var reader = new StreamReader(fileName))
            {
                CsvHelper.Configuration.CsvConfiguration cnfg =
                    new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
                cnfg.Encoding = System.Text.Encoding.UTF8;
                cnfg.Delimiter = ",";
                cnfg.HasHeaderRecord = true;
                cnfg.NewLine = System.Environment.NewLine;
                cnfg.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;

                using (var csv = new CsvReader(reader, cnfg))
                {
                    readData = csv.GetRecords<DataObject>().ToList();
                }
            }

            return readData;
        }

        public static void SaveToXML(Project prj, string fileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(Project));
            TextWriter writer = new StreamWriter(fileName);   //"output-example.xml");
            x.Serialize(writer, prj);
        }
    }
}
