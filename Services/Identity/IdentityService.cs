namespace MySimpleBlog.Services.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using MySimpleBlog.Common;
    using MySimpleBlog.Data.Models;
    using MySimpleBlog.Services.Contracts;
    using MySimpleBlog.ViewModels.Identity;

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Result> LoginAsync(LoginInputModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return false;
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (isPasswordValid == false)
            {
                return false;
            }

            var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return result.Succeeded;
        }
        public async Task<Result> RegisterAsync(RegisterInputModel model)
        {
            var checkUser = await this.userManager.FindByEmailAsync(model.Email);

            if (checkUser != null)
            {
                return false;
            }
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
