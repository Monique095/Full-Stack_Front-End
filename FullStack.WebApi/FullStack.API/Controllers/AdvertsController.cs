using FullStack.API.Services;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models.Users;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertsController : ControllerBase
    {
        public IAdverts_Service _adverts_service;

        public AdvertsController(IAdverts_Service adverts_Service)
        {
            _adverts_service = adverts_Service;
        }

        [Authorize]
        [HttpGet("myads")]
        public IActionResult GetMyAdverts()
        {
            var user = (UserModel)HttpContext.Items["User"];
            var result = _adverts_service.GetMyAdverts(user.Id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get()
        {
            var adverts = _adverts_service.GetAllAdverts();
            return Ok(adverts);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var advert = _adverts_service.GetAdvertById(id);
            return Ok(advert);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(AdvertModel advert)
        {
            _adverts_service.CreateAdvert(advert);
            return Ok(advert);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(AdvertModel advert)
        {
            _adverts_service.UpdateAdvert(advert);
            return Ok(advert);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _adverts_service.DeleteAdvert(id);
            return Ok();
        }
  
    }
}
