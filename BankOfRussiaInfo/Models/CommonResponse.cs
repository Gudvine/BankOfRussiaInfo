using System;

namespace BankOfRussiaInfo.Models
{
    /// <summary>
    /// Представляет обертку над запросом с основной информацией
    /// </summary>
    public class CommonResponse
    {
        /// <summary>
        /// Строкка со статусом запроса
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Дата операции
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Рабочая нагрузка запроса (данные)
        /// </summary>
        public object Data { get; set; }
    }
}
