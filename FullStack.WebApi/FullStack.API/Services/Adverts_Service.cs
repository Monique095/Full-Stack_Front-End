using FullStack.Data.Entities;
using FullStack.ViewModels;
using FullStack.ViewModels.Advert_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace FullStack.API.Services
{
    public interface IAdverts_Service
    {
        IEnumerable<Advert> GetAllAdverts();
        Advert GetAdvertById(int id);
        void CreateAdvert(Advert advert);
        void UpdateAdvert(Advert model);
        void DeleteAdvert(int id);
    }
    public class Adverts_Service : IAdverts_Service
    {
        private FullStackDbContext _context;

        public Adverts_Service( FullStackDbContext context )
        {
            _context = context;
        }

      

        public IEnumerable<Advert> GetAllAdverts()
        {
            return _context.Adverts;
        }

        public Advert GetAdvertById( int id )
        {
            return _context.Adverts.Find(id);
        }


        public void CreateAdvert(Advert advert)
        {
            _context.Adverts.Add(advert);
            _context.SaveChanges();

        }
       
        public void UpdateAdvert( Advert advert)
        {
            _context.Entry(advert).State = EntityState.Modified;
            _context.SaveChanges();
                        
        }

        public void DeleteAdvert ( int id )
        {
            var _advert = _context.Adverts.Find(id);
            if ( _advert != null )
            {
                _context.Adverts.Remove(_advert);
                _context.SaveChanges();
            }
        }

       

    }
}
