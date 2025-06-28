using BankOfRussiaInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetRates([FromQuery] string rateDate, [FromQuery] string currencyCode)
        {
            return Ok(new CommonResponse()
            {
                Date = DateTime.Today,
                Status = "Статус",
                Data = Enumerable.Empty<CurrancyRate>().ToList()

            });
        }
    }
}
