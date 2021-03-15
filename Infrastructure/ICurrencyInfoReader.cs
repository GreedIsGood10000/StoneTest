using System;
using System.Threading;
using System.Threading.Tasks;
using StoneTest.Infrastructure.XmlModels;

namespace StoneTest.Infrastructure
{
    public interface ICurrencyInfoReader
    {
        Task<CurrencyRateList> GetCurrencyRatesForDate(DateTime currencyRatesDate);

        Task<CurrencyList> GetCurrencies();
    }
}