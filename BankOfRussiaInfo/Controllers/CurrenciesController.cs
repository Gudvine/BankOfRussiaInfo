using BankOfRussiaInfo.Models;
using BankOfRussiaInfo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfRussiaInfo.Controllers
{
    /// <summary>
    /// Валюты
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly BankOfRussiaService _bankOfRussiaService;

        public CurrenciesController(BankOfRussiaService bankOfRussiaService)
        {
            _bankOfRussiaService = bankOfRussiaService;
        }

        /// <summary>
        /// Получить курсы валют
        /// </summary>
        /// <param name="rateDate">Дата курса (если не передана, то используется текущая дата)</param>
        /// <param name="currencyCode">Код валюты (если не передан, то список всех валют)</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<CommonResponse<List<CurrancyRate>>>> GetRates([FromQuery] DateTime? rateDate, [FromQuery] string currencyCode)
        {
            var rates = await _bankOfRussiaService.GetCurrancyRatesAsync(rateDate, currencyCode);

            if (rates.Count <= 0)
                return NoContent();

            return Ok(new CommonResponse<List<CurrancyRate>>()
            {
                Status = "Успешно",
                Data = rates
            });
        }
    }
}
