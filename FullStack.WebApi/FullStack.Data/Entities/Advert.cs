using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApi.Entities;

namespace FullStack.Data.Entities
{
   public  class Advert
    {
        public int Id { get; set; }
        public string AdvertHeadlineText { get; set; }
        public string AdvertDetail { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
    }

   
}
