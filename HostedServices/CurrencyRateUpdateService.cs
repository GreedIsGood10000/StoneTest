using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoneTest.Infrastructure;

namespace StoneTest.HostedServices
{
    public class CurrencyRateUpdateService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<CurrencyRateUpdateService> _logger;

        public CurrencyRateUpdateService(
            IServiceScopeFactory scopeFactory,
            ILogger<CurrencyRateUpdateService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var currencyRatesUpdater = scope.ServiceProvider.GetRequiredService<ICurrencyRatesUpdater>();

                        await currencyRatesUpdater.Update();
                    }

                    var millisecondsUntilTomorrow = GetMillisecondsUntilTomorrow();
                    await Task.Delay(millisecondsUntilTomorrow, cancellationToken);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        private static int GetMillisecondsUntilTomorrow()
        {
            var currentDate = DateTime.Now;
            var millisecondsUntilTomorrow = (int) Math.Ceiling((currentDate.AddDays(1).Date - currentDate).TotalMilliseconds);
            return millisecondsUntilTomorrow;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
