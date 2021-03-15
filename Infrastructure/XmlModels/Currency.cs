using System.Xml.Serialization;

namespace StoneTest.Infrastructure.XmlModels
{
    public class Currency
    {
        //предположим, что поля данное поле и все остальные обязательны и не нулябельны
        [XmlAttribute("ID")]
        public string ID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("EngName")]
        public string EngName { get; set; }

        [XmlElement("Nominal")]
        public int Nominal { get; set; }

        [XmlElement("ParentCode")]
        public string ParentCode { get; set; }

        [XmlElement("ISO_Num_Code")]
        public string NumCode { get; set; }

        [XmlElement("ISO_Char_Code")]
        public string CharCode { get; set; }
    }
}
