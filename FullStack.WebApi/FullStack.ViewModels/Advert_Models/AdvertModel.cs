namespace FullStack.ViewModels
{
    public class AdvertModel
    {
        public int Id { get; set; }
        public string AdvertHeadlineText { get; set; }
        public string AdvertDetail { get; set; }
        public string Province { get; set; }
        public int ProvinceId { get; set; }
       public string City { get; set; }
       public int CityId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
    }
}

