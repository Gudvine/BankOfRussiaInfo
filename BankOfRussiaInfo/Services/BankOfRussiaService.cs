using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public async Task<List<CurrancyRate>> GetCurrancyRatesAsync(DateTime? date, string currencyCode = null)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_cbrBaseAddress);

            string dateReq;

            // формат параметра для апи ЦБ (req_date=dd/MM/yyyy)
            if (date.HasValue)
                dateReq = date.Value.ToString("dd/MM/yyyy");
            else
                dateReq = DateTime.Today.ToString("dd/MM/yyyy");

            var response = await client.GetAsync($"XML_daily.asp?date_req={dateReq}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Не удоалось получить данные с ЦБ России");

            var xmlContent = await response.Content.ReadAsStringAsync();

            var rates = ParseBankXmlContentFromString(xmlContent);

            if (!string.IsNullOrEmpty(currencyCode))
                return rates.Where(x => x.CurrancyCode == currencyCode).ToList();

            return rates;
        }

        /// <summary>
        /// Распарсить XML ответ от ЦБ в список котировок
        /// </summary>
        private List<CurrancyRate> ParseBankXmlContentFromString(string xmlContent)
        {
            var rates = Enumerable.Empty<CurrancyRate>().ToList();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            var dateNode = xmlDoc.SelectSingleNode("//ValCurs/@Date");
            var date = DateTime.ParseExact(dateNode.Value, "dd.MM.yyyy", null);

            var valuteNodes = xmlDoc.SelectNodes("//Valute");

            foreach (XmlNode node in valuteNodes)
            {
                var currancyCode = node.SelectSingleNode("CharCode")?.InnerText;
                var rusName = node.SelectSingleNode("Name")?.InnerText;
                var rateValue = decimal.Parse(node.SelectSingleNode("Value")?.InnerText);

                rates.Add(new CurrancyRate
                {
                    CurrancyCode = currancyCode,
                    RateValue = rateValue,
                    RateDate = date,
                    RusName = rusName
                });
            }

            return rates;
        }
    }
}
