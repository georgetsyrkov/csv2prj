using System;

namespace csv2prj
{
    public class DataObject
    {
        [CsvHelper.Configuration.Attributes.Name("Наименование")]
        public string Name {get;set;} = string.Empty;

        [CsvHelper.Configuration.Attributes.Name("Обозначение")]
        public string Code {get;set;} = string.Empty;

        [CsvHelper.Configuration.Attributes.Name("Количество")]
        public float Quantity {get;set;} = 0;

        [CsvHelper.Configuration.Attributes.Name("Длительность")]
        public float Duration {get;set;} = 0;
    }
}