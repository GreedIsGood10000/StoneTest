using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoneTest.Infrastructure.Repositories;

namespace StoneTest.Controllers
{
    public class CurrencyRateController : Controller
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;
        private readonly ILogger<CurrencyRateController> _logger;

        public CurrencyRateController(ICurrencyRateRepository currencyRateRepository,
            ILogger<CurrencyRateController> logger)
        {
            _currencyRateRepository = currencyRateRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyRateByLinq(string charCode, DateTime onDate)
        {
            try
            {
                var currencyRate = await _currencyRateRepository.GetCurrencyRateByLinq(charCode, onDate);

                if (currencyRate != null)
                {
                    return Ok(currencyRate.Value);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyRateBySql(string charCode, DateTime onDate)
        {
            try
            {
                var currencyRate = await _currencyRateRepository.GetCurrencyRateBySql(charCode, onDate);

                if (currencyRate != null)
                {
                    return Ok(currencyRate.Value);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
