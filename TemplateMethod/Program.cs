using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var y = new JSONFile();
            var x = y.Process();

            Console.WriteLine(x);
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

    public class JSONFile : TemperatureRecordParser
    {
        public override void OpenFile(string pathName)
        {



        }
    }

    public class XMLFile : TemperatureRecordParser
    {

        public override void OpenFile(string pathName)
        {

        }
    }

    public class FlatFile : TemperatureRecordParser
    {
        public override void OpenFile(string pathName)
        {

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


