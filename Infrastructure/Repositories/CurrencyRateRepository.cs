using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoneTest.Infrastructure.DbModels;

namespace StoneTest.Infrastructure.Repositories
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly StoneTestContext _dbContext;

        public CurrencyRateRepository(StoneTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrUpdateRange(IEnumerable<CurrencyRate> currencyRates, DateTime onDate)
        {
            var existingCurrencyRates = _dbContext.CurrencyRate.Where(x => x.Date == onDate.Date).ToArray();
            foreach (var currencyRate in currencyRates)
            {
                if (existingCurrencyRates.All(x => x.Id != currencyRate.Id))
                {
                    await _dbContext.CurrencyRate.AddAsync(currencyRate);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<decimal?> GetCurrencyRateByLinq(string charCode, DateTime onDate)
        {
            var result = await _dbContext
                .CurrencyRate
                .FirstOrDefaultAsync(x => x.CharCode == charCode && x.Date == onDate.Date);

            return result?.Value;
        }

        public async Task<decimal?> GetCurrencyRateBySql(string charCode, DateTime onDate)
        {
            var parameter = new SqlParameter
            {
                ParameterName = "@retVal",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Output,
                IsNullable = true,
                Scale = 4
            };

            await _dbContext.Database
                .ExecuteSqlCommandAsync("EXEC @retVal = Get_CurrencyRate @p0, @p1", charCode, onDate, parameter);

            return parameter.Value == DBNull.Value ? null : (decimal?) parameter.Value;
        }
    }
}
