using Bingo.Data.Entities;
using Bingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.Controllers
{
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        IAdminService _adminService;

        public AdminController(IAdminService AdminService)
        {
            _adminService = AdminService;
        }

        [HttpPost]
        public void PostAdmin([FromBody] Admin admin)
        {
            _adminService.PostAdmin(admin);
        }

    }
}