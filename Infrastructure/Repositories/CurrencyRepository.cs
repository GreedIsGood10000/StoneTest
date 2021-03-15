using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoneTest.Infrastructure.DbModels;

namespace StoneTest.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly StoneTestContext _dbContext;

        public CurrencyRepository(StoneTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrUpdateRange(IEnumerable<Currency> currencies)
        {
            var existingCurrencies = _dbContext.Currency.ToArray();
            foreach (var currency in currencies)
            {
                if (existingCurrencies.All(x => x.Id != currency.Id))
                {
                    await _dbContext.Currency.AddAsync(currency);
                }
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
