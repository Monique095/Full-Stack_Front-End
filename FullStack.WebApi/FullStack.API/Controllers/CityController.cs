using FullStack.API.Services;
using FullStack.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("City")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var adverts = _cityService.GetCities();
            return Ok(adverts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var advert = _cityService.GetCity(id);
            return Ok(advert);
        }

        [Route("CityData")]
        [HttpGet]
        public IActionResult GetCityWithProvince(int provinceId)
        {
            var advert = _cityService.GetProvinceByCity(provinceId);
            return Ok(advert);
        }

    }
}
