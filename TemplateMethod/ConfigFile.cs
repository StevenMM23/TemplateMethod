using System;
using System.Xml.Serialization;

namespace TemplateMethod
{
    public class ConfigFile
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Meassure { get; set; }
    }
}
