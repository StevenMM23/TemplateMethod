using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace TemplateMethod
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var FlatFile = new FlatFileRecordParser();
            FlatFile.OpenFile(@"C:\Users\estev\Desktop\New folder\VisualReact\TemplateMethod\TemplateMethod\sample-files\TextFile1.txt");

            Console.ReadKey();

        }
    }

    public abstract class TemperatureRecordParser
    {
        protected List<double> _allTemperature { get; set; }

        protected TemperatureRecordParser()
        {
            _allTemperature = new List<double>();
        }

        public Stats Process()
        {
            var min = _allTemperature.Min();
            var max = _allTemperature.Max();
            var average = _allTemperature.Average();
            return new Stats(average, max, min);
        }

        public abstract void OpenFile(string pathName);
    }

    public class JsonRecordParser : TemperatureRecordParser
    {
        public override void OpenFile(string pathName)
        {
            var jsonObject = JsonConvert.DeserializeObject<List<ConfigFile>>(File.ReadAllText(pathName));

            _allTemperature.Clear();

            foreach (var obj in jsonObject) _allTemperature.Add(obj.meassure);

            var result = Process();
            Console.WriteLine($"El promedio del archivo es de: {result.AvgTemp}");
            Console.WriteLine($"El Maximo del archivo es de: {result.MaxTemp}");
            Console.WriteLine($"El Minimo del archivo es de: {result.MinTemp}");
        }
    }

    public class XmlRecordParser : TemperatureRecordParser
    {
        public override void OpenFile(string pathName)
        {
            var file = new StreamReader(pathName);
            var xmlSerializer = new XmlSerializer(typeof(Collection<ConfigFile>));

            var xml = (List<ConfigFile>)xmlSerializer.Deserialize(file);

            foreach (var x in xml)
            {
                _allTemperature.Add(x.meassure);
            }

            var result = Process();
            Console.WriteLine($"El promedio del archivo XML es de: {result.AvgTemp}");
            Console.WriteLine($"El Maximo del archivo XML es de: {result.MaxTemp}");
            Console.WriteLine($"El Minimo del archivo XML es de: {result.MinTemp}");
        }
    }


    public class FlatFileRecordParser : TemperatureRecordParser
    {
        public override void OpenFile(string pathName)
        {
            var jsonObject = File.ReadAllText(pathName).Split('|');

            _allTemperature.Add(Convert.ToDouble(jsonObject[6].Remove(jsonObject[6].Length - 1).Trim()));

            _allTemperature.Add(Convert.ToDouble(jsonObject[9].Remove(jsonObject[9].Length - 1).Trim()));

            _allTemperature.Add(Convert.ToDouble(jsonObject[12].Remove(jsonObject[12].Length - 1).Trim()));


            var result = Process();
            Console.WriteLine($"El promedio del archivo es de: {result.AvgTemp}");
            Console.WriteLine($"El Maximo del archivo es de: {result.MaxTemp}");
            Console.WriteLine($"El Minimo del archivo es de: {result.MinTemp}");
        }
    }

    public class Stats
    {
        public double AvgTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }

        public Stats(double avgTemp, double maxTemp, double minTemp)
        {
            AvgTemp = avgTemp;
            MaxTemp = maxTemp;
            MinTemp = minTemp;
        }
    }
}