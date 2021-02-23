
using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace FullStack.Data
{
    public interface IFullStackRepository
    {
        //Users
        User GetUser(int id);
        List<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);

        //adverts
        Advert GetAdvert(int id);
        List<Advert> GetAdverts();
        List<Advert> GetAdvertsByUserId(int userId);
        Advert CreateAdvert(Advert advert);
        Advert UpdateAdvert(Advert advert);
        void DeleteAdvert(int id);

        //provinces
        Province GetProvinceById(int id);
        List<Province> GetProvinces();

        //cities
        City GetCityById(int id);
        List<City> GetCities();
        List<City> GetCitiesForProvince(int provinceId);
    }
    public class FullStackRepository: IFullStackRepository
    {
        private FullStackDbContext _ctx;
        public FullStackRepository(FullStackDbContext ctx)
        {
            _ctx = ctx;
        }


        //USERS
        public List<User> GetUsers()
        {
            return _ctx.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _ctx.Users.Find(id);
        }

        public User CreateUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            var existing = _ctx.Users.SingleOrDefault(em => em.Id == user.Id);
            if (existing == null) return null;

            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Users.Attach(user);
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.SaveChanges();
            return existing;
        }

        public void DeleteUser(int id)
        {
            var entity = _ctx.Users.Find(id);
            _ctx.Users.Remove(entity); 
            _ctx.SaveChanges();
        }


        //ADVERTS
        public Advert GetAdvert(int id)
        {
            return _ctx.Adverts.FirstOrDefault(a => a.Id == id);
        }

        public List<Advert> GetAdverts()
        {
            return _ctx.Adverts.Where(c => c.Status  == "LIVE").ToList(); ;
        }

        public List<Advert> GetAdvertsByUserId(int userId)
        {
            return _ctx.Adverts.Where(a => a.UserId == userId).ToList();
        }

        public Advert CreateAdvert(Advert advert)
        {
            _ctx.Adverts.Add(advert);
            _ctx.SaveChanges();
            return advert;
        }

        public Advert UpdateAdvert(Advert advert)
        {
            var existing = _ctx.Adverts.SingleOrDefault(em => em.Id == advert.Id);
            if (existing == null) return null;

            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Adverts.Attach(advert);
            _ctx.Entry(advert).State = EntityState.Modified;
            _ctx.SaveChanges();
            return existing;
        }

        public void DeleteAdvert(int id)
        {
             var entity = _ctx.Adverts.Find(id);
            _ctx.Adverts.Remove(entity); 
            _ctx.SaveChanges();
        }


        //PROVINCES 
        public Province GetProvinceById(int id)
        {
            return _ctx.Provinces.FirstOrDefault(a => a.Id == id);
        }

        public List<Province> GetProvinces()
        {
            
            return _ctx.Provinces.ToList();
        }

        //CITIES
        public City GetCityById(int id)
        {
            return _ctx.Cities.FirstOrDefault(a => a.Id == id);
        }
        public List<City> GetCities()
        {
            return _ctx.Cities.ToList();
        }

        public List<City> GetCitiesForProvince(int provinceId)
        {
            return _ctx.Cities.Where(c => c.ProvinceId == provinceId).ToList();
        }

        
    }
}
