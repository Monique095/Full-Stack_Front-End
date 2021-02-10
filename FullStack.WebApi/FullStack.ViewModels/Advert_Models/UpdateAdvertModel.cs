using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models.Users;

namespace FullStack.ViewModels.Advert_Models
{
     public class UpdateAdvertModel
    {
        public int Id { get; set; }
        public string AdvertHeadlineText { get; set; }
        public string AdvertDetail { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }

    }
}
