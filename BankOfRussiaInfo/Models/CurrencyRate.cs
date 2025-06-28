using System;

namespace BankOfRussiaInfo
{
    public class CurrancyRate
    {
        /// <summary>
        /// Код валюты (RUR, USD, etc.)
        /// </summary>
        public string CurrancyCode { get; set; }
        
        /// <summary>
        /// Русское название валюты (Японская йена, Российский рубль, etc.)
        /// </summary>
        public string RusName { get; set; }

        /// <summary>
        /// Котировака валюты
        /// </summary>
        public decimal RateValue { get; set; }

        /// <summary>
        /// Дата котировки
        /// </summary>
        public DateTime RateDate { get; set; }
    }
}