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

            List<int> rootTaskIDs = new List<int>();

            int taskIndex = 1;
            for (int i = 0; i < csvData.Count; i++)
            {
                Task newTask = new Task();
                newTask.Name = string.Format("{0} ({1})", csvData[i].Name, csvData[i].Code);
                newTask.ID = taskIndex;
                newTask.UID = taskIndex;
                newTask.Duration = ConvertDuration(csvData[i].Duration);

                rootTaskIDs.Add(taskIndex);
                prj.Tasks.Add(newTask); taskIndex++;

                if (csvData[i].Type == "С")
                {
                    Task subTask1 = new Task();
                    subTask1.OutlineLevel = 2;
                    subTask1.Name = "Установка деталей для " + csvData[i].Code;
                    subTask1.ID = taskIndex;
                    subTask1.UID = taskIndex;
                    subTask1.Duration = ConvertDuration(csvData[i].Duration / 2);
                    prj.Tasks.Add(subTask1); taskIndex++;

                    Task subTask2 = new Task();
                    subTask2.OutlineLevel = 2;
                    subTask2.Name = "Сборка деталей для " + csvData[i].Code;
                    subTask2.ID = taskIndex;
                    subTask2.UID = taskIndex;
                    subTask2.Duration = ConvertDuration(csvData[i].Duration / 2);
                    prj.Tasks.Add(subTask2); taskIndex++;

                    subTask2.PredecessorLinks.Add(new PredecessorLink() {PredecessorUID = subTask1.UID});
                }
                else
                {
                    Task subTask1 = new Task();
                    subTask1.OutlineLevel = 2;
                    subTask1.Name = "Получение заготовки для " + csvData[i].Code;
                    subTask1.ID = taskIndex;
                    subTask1.UID = taskIndex;
                    subTask1.Duration = ConvertDuration(csvData[i].Duration / 3);
                    prj.Tasks.Add(subTask1); taskIndex++;

                    Task subTask2 = new Task();
                    subTask2.OutlineLevel = 2;
                    subTask2.Name = "Механообработка " + csvData[i].Code;
                    subTask2.ID = taskIndex;
                    subTask2.UID = taskIndex;
                    subTask2.Duration = ConvertDuration(csvData[i].Duration / 3);
                    prj.Tasks.Add(subTask2); taskIndex++;

                    subTask2.PredecessorLinks.Add(new PredecessorLink() {PredecessorUID = subTask1.UID});

                    Task subTask3 = new Task();
                    subTask3.OutlineLevel = 2;
                    subTask3.Name = "Слесарные операции " + csvData[i].Code;
                    subTask3.ID = taskIndex;
                    subTask3.UID = taskIndex;
                    subTask3.Duration = ConvertDuration(csvData[i].Duration / 3);
                    prj.Tasks.Add(subTask3); taskIndex++;

                    subTask3.PredecessorLinks.Add(new PredecessorLink() {PredecessorUID = subTask2.UID});
                }

                if (i < csvData.Count - 1)
                {
                    newTask.PredecessorLinks.Add(new PredecessorLink() { PredecessorUID = taskIndex });
                }
            }

            SaveToXML(prj, "output-example.xml");

            Console.WriteLine($"readData.Count={csvData.Count}");
            for (int i = 0; i < csvData.Count; i++)
            {
                Console.WriteLine($"[{i}]: Name={csvData[i].Name}; Code={csvData[i].Code}; Quantity={csvData[i].Quantity};");
            }
        }

        public static string ConvertDuration(float hours)
        {
            string output = "PT00H00M00S";
            TimeSpan ts = TimeSpan.FromHours(hours);
            output = $"PT{ts.Hours}H{ts.Minutes}M{ts.Seconds}S";
            return output;
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
