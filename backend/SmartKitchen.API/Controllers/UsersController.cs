using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartkitchen.API.Data;
using Smartkitchen.API.Models;

namespace Smartkitchen.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SmartKitchenContext _context;

        public UserController(SmartKitchenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User User)
        {

        }

    }
}
