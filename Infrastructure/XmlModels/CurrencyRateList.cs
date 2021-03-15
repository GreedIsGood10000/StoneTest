using System.Xml.Serialization;

namespace StoneTest.Infrastructure.XmlModels
{
    [XmlRoot("ValCurs")]
    public class CurrencyRateList
    {
        //предположим, что поля данное поле и все остальные обязательны и не нулябельны
        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Valute")]
        public CurrencyRate[] CurrencyRates { get; set; }
    }
}
