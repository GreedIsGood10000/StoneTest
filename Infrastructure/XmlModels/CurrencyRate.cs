using System.Xml.Serialization;

namespace StoneTest.Infrastructure.XmlModels
{
    public class CurrencyRate
    {
        //предположим, что поля данное поле и все остальные обязательны и не нулябельны
        [XmlAttribute("ID")]
        public string ID { get; set; }

        [XmlElement("NumCode")]
        public string NumberCode { get; set; }

        [XmlElement("CharCode")]
        public string CharCode { get; set; }

        [XmlElement("Nominal")]
        public int Nominal { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Value")]
        public string Value { get; set; }
    }
}