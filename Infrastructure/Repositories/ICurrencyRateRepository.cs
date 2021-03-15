using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoneTest.Infrastructure.DbModels;

namespace StoneTest.Infrastructure.Repositories
{
    public interface ICurrencyRateRepository
    {
        Task AddOrUpdateRange(IEnumerable<CurrencyRate> currencyRates, DateTime onDate);

        Task<decimal?> GetCurrencyRateByLinq(string charCode, DateTime onDate);

        Task<decimal?> GetCurrencyRateBySql(string charCode, DateTime onDate);
    }
}