using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DataServer;
using DataConsumer;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelAPIController : ControllerBase
    {

        private readonly ILogger<HotelAPIController> _logger;
        private readonly IGetCountryData oGetCountryData = CountryDataCache.GetInstance(new HotelAPIDataConsumer());

        public HotelAPIController(ILogger<HotelAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{pIso}")]
        public object Get(string pIso)
        {
            object oResponse;
            this.oGetCountryData.IGetCountryData(pIso.ToUpper(), out oResponse);

            if(oResponse is null || oResponse is string)
            {
                throw new ArgumentException(
                    string.Concat(
                        "Http Error: " ,
                        oResponse));
            }

            return oResponse;
        }
    }
}
