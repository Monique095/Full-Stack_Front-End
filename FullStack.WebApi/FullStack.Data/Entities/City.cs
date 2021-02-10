using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullStack.Data.Entities
{
   public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
