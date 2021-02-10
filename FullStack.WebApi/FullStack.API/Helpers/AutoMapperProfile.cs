using AutoMapper;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using FullStack.ViewModels.Advert_Models;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<Advert, AdvertModel>();
            CreateMap<CreateModel, Advert>();
            CreateMap<UpdateAdvertModel, Advert>();
        }
    }
}