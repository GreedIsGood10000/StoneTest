namespace StoneTest.Infrastructure.Extensions
{
    public static class CurrencyExtension
    {
        public static DbModels.Currency ConvertToDbValue(this XmlModels.Currency xmlCurrency)
        {
            return new DbModels.Currency
            {
                Id = xmlCurrency.ID,
                CharCode = xmlCurrency.CharCode,
                EngName = xmlCurrency.EngName,
                Name = xmlCurrency.Name,
                Nominal = xmlCurrency.Nominal,
                NumCode = xmlCurrency.NumCode,
                ParentCode = xmlCurrency.ParentCode
            };
        }
    }
}
