using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class FullStackDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public FullStackDbContext(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Connect to SQL DB!
            options.UseSqlServer(Configuration.GetConnectionString("WebApi"));

        }

        //Seed Data to DB!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, ProvinceName = "Free State" },
                new Province { Id = 2, ProvinceName = "Gauteng" },
                new Province { Id = 3, ProvinceName = "Western Cape" },
                new Province { Id = 4, ProvinceName = "KwaZulu Natal" },
                new Province { Id = 5, ProvinceName = "Mpumalanga" },
                new Province { Id = 6, ProvinceName = "Eastern Cape" },
                new Province { Id = 7, ProvinceName = "North West" }
            );

            modelBuilder.Entity<City>().HasData(
                 new City { Id = 1, CityName = "Bloemfontein", ProvinceId = 1 },
                 new City { Id = 2, CityName = "Bethlehem", ProvinceId = 1 },
                 new City { Id = 3, CityName = "Pretoria", ProvinceId = 2 },
                 new City { Id = 4, CityName = "Johannesburg", ProvinceId = 2 },
                 new City { Id = 5, CityName = "Cape Town", ProvinceId = 3 },
                 new City { Id = 6, CityName = "Somerset West", ProvinceId = 3 },
                 new City { Id = 7, CityName = "Durban", ProvinceId = 4 },
                 new City { Id = 8, CityName = "Pietermaritzburg", ProvinceId = 4 },
                 new City { Id = 9, CityName = "Nelspruit", ProvinceId = 5 },
                 new City { Id = 10, CityName = "Witbank", ProvinceId = 5 },
                 new City { Id = 11, CityName = "Port Elizabeth", ProvinceId = 6 },
                 new City { Id = 12, CityName = "East London", ProvinceId = 6 },
                 new City { Id = 13, CityName = "Rustenburg", ProvinceId = 7 },
                 new City { Id = 14, CityName = "Potchefstroom", ProvinceId = 7 }
          );
        }
     }
}