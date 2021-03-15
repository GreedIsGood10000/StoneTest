using System.Threading.Tasks;

namespace StoneTest.Infrastructure
{
    public interface ICurrencyRatesUpdater
    {
        Task Update();
    }
}