using Microsoft.AspNetCore.Mvc;
using MySimpleBlog.Services.Contracts;
using MySimpleBlog.ViewModels.Identity;
using System.Threading.Tasks;

namespace MySimpleBlog.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var result = await this.identityService.LoginAsync(model);

            if (!result.Succeeded)
            {
                return this.BadRequest("Incorrect email or password!");
            }

            return this.Ok();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            var result = await this.identityService.RegisterAsync(model);

            if (!result.Succeeded)
            {
                return this.BadRequest("There is already user registered with this email!");
            }

            return this.Ok();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task Logout()
        {
            await this.identityService.Logout();
        }
    }
}
