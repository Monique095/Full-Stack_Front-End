using FullStack.Data;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace FullStack.API.Services
{
    public interface IAdverts_Service
    {
        IEnumerable<AdvertModel> GetAllAdverts();
        IEnumerable<AdvertModel> GetMyAdverts(int userId);
        AdvertModel GetAdvertById(int id);
        AdvertModel CreateAdvert(AdvertModel advert);
        AdvertModel UpdateAdvert(AdvertModel model);
        void DeleteAdvert(int id);

    }
    public class AdvertService : IAdverts_Service
    {
        private IFullStackRepository _repo;
        public AdvertService(IFullStackRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<AdvertModel> GetAllAdverts()
        {
            var advert = _repo.GetAdverts();
            return advert.Select(advertModel => Map(advertModel)) ;
        }

        public AdvertModel GetAdvertById( int id)
        {
            var advert = _repo.GetAdvert(id);
            if (advert == null) return null;
            return Map(advert);
        }

        public IEnumerable<AdvertModel> GetMyAdverts(int userId)
        {
            var adverts = _repo.GetAdvertsByUserId(userId);
            return adverts.Select(advertModel => Map(advertModel));
        }

        public AdvertModel CreateAdvert(AdvertModel advertModel)
        {
            var advert = Map(advertModel);
             _repo.CreateAdvert(advert);
            var createdAdvert = Map(advert);
            return createdAdvert;
        }

        public AdvertModel UpdateAdvert(AdvertModel advertModel)
        {
            var advert = Map(advertModel);
            _repo.UpdateAdvert(advert);
            var updatedAdvert = Map(advert);
            return updatedAdvert;
        }

        public void DeleteAdvert ( int id )
        {
            _repo.DeleteAdvert(id);
        }

        private AdvertModel Map (Advert advert)
        {
           var province = _repo.GetProvinceById(advert.ProvinceId);
           var city = _repo.GetCityById(advert.CityId);

            return new AdvertModel
            {
                Id = advert.Id,
                AdvertHeadlineText = advert.AdvertHeadlineText,
                AdvertDetail = advert.AdvertDetail,
                Price = advert.Price,
                Province = province.ProvinceName,
                ProvinceId = province.Id,
                City = city.CityName,
                CityId = city.Id,
                Status = advert.Status,
                UserId = advert.UserId,
            };
        }

        private Advert Map(AdvertModel model)
        {
            return new Advert
            {
                Id = model.Id,
                AdvertHeadlineText = model.AdvertHeadlineText,
                AdvertDetail = model.AdvertDetail,
                Price = model.Price,
                ProvinceId = model.ProvinceId,
                CityId = model.CityId,
                Status = model.Status,
                UserId = model.UserId,
            };
        }
    }
}
