using System;
using System.Globalization;

namespace StoneTest.Infrastructure.Extensions
{
    public static class CurrencyRateExtension
    {
        public static DbModels.CurrencyRate ConvertToDbValue(this XmlModels.CurrencyRate xmlCurrencyRate, DateTime currencyRateDate)
        {
            return new DbModels.CurrencyRate
            {
                CharCode = xmlCurrencyRate.CharCode,
                Date = currencyRateDate,
                Value = decimal.Parse(xmlCurrencyRate.Value, CultureInfo.GetCultureInfo("RU-ru")),
                Id = xmlCurrencyRate.ID,
                Name = xmlCurrencyRate.Name,
                Nominal = xmlCurrencyRate.Nominal,
                NumCode = xmlCurrencyRate.NumberCode
            };
        }
    }
}
