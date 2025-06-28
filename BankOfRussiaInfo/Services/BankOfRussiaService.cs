using System.Net.Http;

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
        private const string _cbrBaseAddress = "https://cbr.ru/scripts";

        public BankOfRussiaService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<CurrancyRate> GetCurrancyRates()
        {
            //var client = _httpClientFactory.Cre
        }
    }
}
