using Bingo.Data.Entities;
using Bingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public void PostUser([FromBody] User user)
        {
            _userService.PostUser(user);
        }

    }
}