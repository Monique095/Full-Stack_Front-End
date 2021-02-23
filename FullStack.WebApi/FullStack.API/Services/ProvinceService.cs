using FullStack.Data;
using FullStack.Data.Entities;
using FullStack.ViewModels.Advert_Models;
using System.Collections.Generic;
using System.Linq;

namespace FullStack.API.Services
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceModel> GetProvinces();
        ProvinceModel GetProvince(int id);
    }

    public class ProvinceService : IProvinceService
    {
        private IFullStackRepository _repo;

        public ProvinceService(IFullStackRepository repo)
        {
            _repo = repo;
        }

        public ProvinceModel GetProvince(int id)
        {
            var province = _repo.GetProvinceById(id);
            return Map(province);
        }

        public IEnumerable<ProvinceModel> GetProvinces()
        {
            var province = _repo.GetProvinces();
            return province.Select(ProvinceModels => Map(ProvinceModels));
        }

        private ProvinceModel Map(Province province)
        {
            return new ProvinceModel
            {
                Id = province.Id,
                ProvinceName = province.ProvinceName,
            };
        }
    }
}