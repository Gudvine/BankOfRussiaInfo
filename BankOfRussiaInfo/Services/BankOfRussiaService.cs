using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankOfRussiaInfo.Services
{
    /// <summary>
    /// Сервис вазимодействия с Банком России
    /// </summary>
    public class BankOfRussiaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Базовый адрес для запросов к API Банка России
        /// </summary>
        private const string _cbrBaseAddress = "https://cbr.ru/scripts/";

        public BankOfRussiaService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CurrancyRate>> GetCurrancyRatesAsync(DateTime? date, string currencyCode)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_cbrBaseAddress);

            // формат параметра для апи ЦБ (req_date=dd/MM/yyyy)
            var dateReq = date.Value.ToString("dd/MM/yyyy") ?? DateTime.Today.ToString("dd/MM/yyyy");

            var response = await client.GetAsync($"{_cbrBaseAddress}XML_daily.asp?date_req={dateReq}");
            

            return null;
        }
    }
}
