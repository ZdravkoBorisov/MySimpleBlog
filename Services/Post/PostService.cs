namespace MySimpleBlog.Services.Post
{
    using System.Threading.Tasks;
    using System.Linq;

    using MySimpleBlog.Common;
    using MySimpleBlog.Data;
    using MySimpleBlog.Data.Models;
    using MySimpleBlog.Services.Contracts;

    using Microsoft.EntityFrameworkCore;
    using MySimpleBlog.ViewModels.Post;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext postsDb;

        public PostService(ApplicationDbContext postsDb)
        {
            this.postsDb = postsDb;
        }

        public async Task<Result> CreateAsync(CreatePostViewModel viewModel, string userId)
        {
            var checkIfPostExists = await this.postsDb
                .Posts
                .Where(x => x.Title == viewModel.Title)
                .FirstOrDefaultAsync();

            if (checkIfPostExists != null)
            {
                return "Post already exists!";
            }

            var post = new Post()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                UserId = userId,
            };

            await this.postsDb.Posts.AddAsync(post);
            await this.postsDb.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var post = await this.postsDb.Posts
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return "This post doesn't exist!";
            }

            this.postsDb.Posts.Remove(post);
            await this.postsDb.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(EditPostViewModel viewModel)
        {
            var post = await this.postsDb.Posts
                .Where(x => x.Id == viewModel.Id)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return "Post doesn't exist.";
            }

            post.Title = viewModel.Title;
            post.Description = viewModel.Title;

            await this.postsDb.SaveChangesAsync();

            return true;
        }

        public async Task<Post> GetByIdAsync(string id)
        => await this.postsDb.Posts
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}
