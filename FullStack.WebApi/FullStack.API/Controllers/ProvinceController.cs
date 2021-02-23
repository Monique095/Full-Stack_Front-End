using FullStack.API.Services;
using FullStack.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : ControllerBase
    {
        private IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var adverts = _provinceService.GetProvinces();
            return Ok(adverts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var advert = _provinceService.GetProvince(id);
            return Ok(advert);
        }

    }
}
