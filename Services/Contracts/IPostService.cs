namespace MySimpleBlog.Services.Contracts
{
    using System.Threading.Tasks;

    using MySimpleBlog.Common;
    using MySimpleBlog.Data.Models;
    using MySimpleBlog.ViewModels.Post;

    public interface IPostService
    {
        Task<Result> CreateAsync(CreatePostViewModel viewModel,string userId);

        Task<Result> EditAsync(EditPostViewModel viewModel);

        Task<Result> DeleteAsync(string id);

        Task<Post> GetByIdAsync(string id);
    }
}
