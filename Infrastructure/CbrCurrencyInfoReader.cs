using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using StoneTest.Infrastructure.XmlModels;

namespace StoneTest.Infrastructure
{
    public class CbrCurrencyInfoReader : ICurrencyInfoReader
    {
        private readonly HttpClient _cbrHttpClient;
        private readonly IConfiguration _configuration;
        private readonly Encoding _responseEncoding;

        public CbrCurrencyInfoReader(HttpClient cbrHttpClient,
            IConfiguration configuration)
        {
            _cbrHttpClient = cbrHttpClient;
            _configuration = configuration;
            _responseEncoding = Encoding.GetEncoding("windows-1251");
        }

        public async Task<CurrencyRateList> GetCurrencyRatesForDate(DateTime currencyRatesDate)
        {
            var cbrUrl = GetCurrencyRatesUrl(currencyRatesDate);
            var receivedString = await GetContentAsString(cbrUrl);

            return DeserializeResult<CurrencyRateList>(receivedString);
        }

        public async Task<CurrencyList> GetCurrencies()
        {
            var cbrUrl = _configuration.GetSection("ServiceSettings:CbrCurrenciesUrl").Value;
            var receivedString = await GetContentAsString(cbrUrl);

            return DeserializeResult<CurrencyList>(receivedString);
        }

        private async Task<string> GetContentAsString(string cbrUrl)
        {
            var currencyRateResponse = await _cbrHttpClient.GetAsync(cbrUrl);
            var currencyRatesContentStream = await currencyRateResponse.Content.ReadAsStreamAsync();

            using (var streamReader = new StreamReader(currencyRatesContentStream, _responseEncoding))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        private string GetCurrencyRatesUrl(DateTime currencyRatesDate)
        {
            var currencyRatesUrl = _configuration.GetSection("ServiceSettings:CbrCurrencyRatesUrl").Value;
            var cbrUrlBuilder = new UriBuilder(currencyRatesUrl)
            {
                Query = $"date_req={currencyRatesDate:dd.MM.yyyy}"
            };
            return cbrUrlBuilder.ToString();
        }

        private static T DeserializeResult<T>(string serializedXml)
        {
            using (var reader = new StringReader(serializedXml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(reader);
            }
        }
    }
}
