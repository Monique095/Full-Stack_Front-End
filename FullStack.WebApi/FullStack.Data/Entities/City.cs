using System.Collections.Generic;

namespace FullStack.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
    }
}
