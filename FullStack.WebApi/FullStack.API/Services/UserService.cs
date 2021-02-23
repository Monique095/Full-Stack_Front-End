using FullStack.Data;
using FullStack.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;

namespace WebApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Create(User user);
        UserModel Update(User user);
    }

    public class UserService : IUserService
    {
        private IFullStackRepository _repo;
        private readonly AppSettings _appSettings;

        public UserService(IFullStackRepository repo, IOptions<AppSettings> appSettings)
        {
            this._repo = repo;
            this._appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //Get the user from the repository / database

            var user = _repo.GetUsers().SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            //map from DB entity to UserModel for the front-end
            var userModel = Map(user);

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(userModel);

            //return the UserModel to the controller, NOT the entity
            return new FullStack.ViewModels.AuthenticateResponse(userModel, token);
        }

        public IEnumerable<UserModel> GetAll()
        {
            //only use for testing
            var userList = _repo.GetUsers();
            return userList.Select(u => Map(u));
        }

        public UserModel GetById(int id)
        {
            var userEntity = _repo.GetUser(id);
            if (userEntity == null) return null;

            return Map(userEntity);
        }

        public UserModel Create(User user)
        {
            _repo.CreateUser(user);
            return Map(user);

        }

        public UserModel Update(User user)
        {
            _repo.UpdateUser(user);
            return Map(user);

        }


        private string GenerateJwtToken(UserModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private UserModel Map(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
            };
        }
    }
}