using System;
using System.Xml.Serialization;

namespace TemplateMethod
{

    public class ConfigFile
    {
        [XmlElement]
        public int id { get; set; }
        [XmlElement]
        public string location { get; set; }

        [XmlElement]
        public DateTime date { get; set; }

        [XmlElement]
        public double meassure { get; set; }
    }
}