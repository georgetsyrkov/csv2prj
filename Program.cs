using System;

namespace csv2prj
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (args.Length > 0)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(args[0]);
                if (fi.Exists)
                {
                    MainParser.ParseCSV(fi.FullName);
                }
                else
                {
                    Console.WriteLine("Файл не существует");
                }
            }
            else
            {
                Console.WriteLine("Необходимо указать имя CSV файла для работы");
            }
            
        }
    }
}
