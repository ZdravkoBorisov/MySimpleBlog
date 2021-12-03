using Microsoft.AspNetCore.Mvc;

namespace MySimpleBlog.Controllers
{
    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login()
        {
            return null;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register()
        {
            return null;
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return null;
        }
    }
}
