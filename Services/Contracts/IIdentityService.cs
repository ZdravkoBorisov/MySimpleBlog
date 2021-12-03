namespace MySimpleBlog.Services.Contracts
{
    using System.Threading.Tasks;

    using MySimpleBlog.Common;
    using MySimpleBlog.ViewModels.Identity;

    public interface IIdentityService
    {
        Task<Result> LoginAsync(LoginInputModel model);

        Task<Result> RegisterAsync(RegisterInputModel model);

        Task Logout();
    }
}
