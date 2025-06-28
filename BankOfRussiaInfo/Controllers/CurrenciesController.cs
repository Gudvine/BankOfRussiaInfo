using Microsoft.AspNetCore.Mvc;
using System;

namespace BankOfRussiaInfo.Controllers
{
    /// <summary>
    /// Валюты
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class CurrenciesController : ControllerBase
    {
        /// <summary>
        /// Получить курсы валют
        /// </summary>
        /// <param name="rateDate">Дата курса (если не передана, то используется текущая дата)</param>
        /// <param name="currencyCode">Код валюты (если не передан, то список всех валют)</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRates([FromQuery] string rateDate, [FromQuery] string currencyCode)
        {
            return Ok();
        }
    }
}
