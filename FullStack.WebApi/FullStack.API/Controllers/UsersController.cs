using FullStack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect OR You are not Registered!" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }


        [HttpGet("unsecure")]
        public IActionResult GetAllUnsecure()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }


        [HttpPost("register")]
        public IActionResult RegisterUser(User user)
        {
            _userService.Create(user);
            return Ok(user);

        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(User user)
        {
            _userService.Update(user);
            return Ok(user);

        }

    }
}
