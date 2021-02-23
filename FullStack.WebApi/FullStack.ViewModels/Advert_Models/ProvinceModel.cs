using System.Collections.Generic;

namespace FullStack.ViewModels.Advert_Models
{
    public class ProvinceModel
   {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public List<CityModel> Cities { get; set; }
    }
}
