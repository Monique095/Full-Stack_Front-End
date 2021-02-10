using AutoMapper;
using FullStack.API.Services;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using FullStack.ViewModels.Advert_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using WebApi.Helpers;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertsController : ControllerBase
    {
        public IAdverts_Service _adverts_service;
        public IMapper _mapper;
        public FullStackDbContext _context;

        public AdvertsController(IAdverts_Service adverts_Service, IMapper mapper, FullStackDbContext context)
        {
            _adverts_service = adverts_Service;
            _mapper = mapper;
            _context = context;

        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAllAdverts()
        {
            var adverts = _adverts_service.GetAllAdverts();
            var model = _mapper.Map<IList<AdvertModel>>(adverts);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdvertById( int id )
        {
            var advert = _adverts_service.GetAdvertById(id);
            var model = _mapper.Map<AdvertModel>(advert);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost("createProduct")]
        public IActionResult CreateProduct([FromBody] CreateModel model)
        {
            var user = _mapper.Map<Advert>(model);
             _adverts_service.CreateAdvert(user);
            return Ok(model);
    
        }
       
        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateAdvertModel model)
        {
            // map model to entity and set id
            var user = _mapper.Map<Advert>(model);
            _adverts_service.UpdateAdvert(user);
            return Ok(model);
       
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvert ( int id )
        {
            _adverts_service.DeleteAdvert(id);
            return Ok();
        }

    }
}
