using System;
using System.Linq;
using System.Threading.Tasks;
using StoneTest.Infrastructure;
using StoneTest.Infrastructure.Extensions;
using StoneTest.Infrastructure.Repositories;

namespace StoneTest.HostedServices.Implementations
{
    public class CurrencyRateUpdater : ICurrencyRatesUpdater
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyRateRepository _currencyRateRepository;
        private readonly ICurrencyInfoReader _currencyRatesReader;

        public CurrencyRateUpdater(ICurrencyRepository currencyRepository,
            ICurrencyInfoReader currencyRatesReader,
            ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRepository = currencyRepository;
            _currencyRateRepository = currencyRateRepository;
            _currencyRatesReader = currencyRatesReader;
        }

        public async Task Update()
        {
            await UpdateCurrencies(_currencyRepository);
            await UpdateCurrencyRates(_currencyRateRepository);
        }

        private async Task UpdateCurrencyRates(ICurrencyRateRepository currencyRateRepository)
        {
            var currencyRateDate = DateTime.Today;
            var currencyRateList = await _currencyRatesReader.GetCurrencyRatesForDate(currencyRateDate);
            var currencyRates = currencyRateList.CurrencyRates.Select(x => x.ConvertToDbValue(currencyRateDate));
            await currencyRateRepository.AddOrUpdateRange(currencyRates, currencyRateDate);
        }

        private async Task UpdateCurrencies(ICurrencyRepository currencyRepository)
        {
            var currencyList = await _currencyRatesReader.GetCurrencies();
            var currencies = currencyList.Currencies.Select(x => x.ConvertToDbValue());
            await currencyRepository.AddOrUpdateRange(currencies);
        }
    }
}
