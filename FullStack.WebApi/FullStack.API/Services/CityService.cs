using FullStack.Data;
using FullStack.Data.Entities;
using FullStack.ViewModels.Advert_Models;
using System.Collections.Generic;
using System.Linq;

namespace FullStack.API.Services
{
    public interface ICityService
    {
        IEnumerable<CityModel> GetCities();
        CityModel GetCity(int id);
        IEnumerable<CityModel> GetProvinceByCity(int provinceId);
    }

    public class CityService : ICityService
    {
        private IFullStackRepository _repo;

        public CityService(IFullStackRepository repo)
        {
            _repo = repo;
        }

        public CityModel GetCity (int id)
        {
            var city = _repo.GetCityById(id);
            if (city == null) return null;
            return Map(city);
        }

        public IEnumerable<CityModel> GetCities()
        {
            var city = _repo.GetCities();
            return city.Select(cityModel => Map(cityModel));

        }

        public IEnumerable<CityModel> GetProvinceByCity(int provinceId)
        {
            var province = _repo.GetCitiesForProvince(provinceId);
            return province.Select(cityModel => Map(cityModel));
        }

        private CityModel Map(City city)
        {
            return new CityModel
            {
                Id = city.Id,
                CityName = city.CityName,
                ProvinceId = city.ProvinceId,         
            };
        }
    }
}
