using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace DataAggregatorClincsSG
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesInDirectory = Directory.GetFiles(@"C:\Users\aciuca\Desktop\clinics");
            var str = new StringBuilder();
            str.AppendLine("Category, Name, Email");
            var count = 0;
            foreach (var file in filesInDirectory)
            {
                using (var r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    dynamic array = JsonConvert.DeserializeObject(json);
                    foreach (var item in array)
                    {
                        str.AppendLine(String.Format("{0},{1},{2}",
                            item.DisplayName, item.Name, item.EMailAppointmentReservationUrl));
                        count++;
                        Console.WriteLine(count);
                    }
                }
            }
            File.WriteAllText(@"C:\Users\aciuca\Desktop\clinics.csv", str.ToString());
            Console.Write("Total number of records: {0}", count);
            Console.Read();
        }
    }
}
