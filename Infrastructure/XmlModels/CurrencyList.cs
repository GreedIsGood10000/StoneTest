using System.Xml.Serialization;

namespace StoneTest.Infrastructure.XmlModels
{
    [XmlRoot("Valuta")]
    public class CurrencyList
    {
        //предположим, что поля данное поле и все остальные обязательны и не нулябельны
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Item")]
        public Currency[] Currencies { get; set; }
    }
}
