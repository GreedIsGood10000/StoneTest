using System.Collections.Generic;
using System.Threading.Tasks;
using StoneTest.Infrastructure.DbModels;

namespace StoneTest.Infrastructure.Repositories
{
    public interface ICurrencyRepository
    {
        Task AddOrUpdateRange(IEnumerable<Currency> currencies);
    }
}