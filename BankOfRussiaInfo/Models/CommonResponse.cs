using System;

namespace BankOfRussiaInfo.Models
{
    /// <summary>
    /// Представляет обертку над запросом с основной информацией
    /// </summary>
    public class CommonResponse<T> where T : class
    {
        /// <summary>
        /// Строкка со статусом запроса
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Дата операции
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Рабочая нагрузка запроса (данные)
        /// </summary>
        public T Data { get; set; }

        public CommonResponse() => Date = DateTime.Now;
    }
}
