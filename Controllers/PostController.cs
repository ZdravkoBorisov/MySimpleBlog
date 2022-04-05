using Microsoft.AspNetCore.Mvc;
using MySimpleBlog.Data.Models;
using MySimpleBlog.Services.Contracts;
using MySimpleBlog.ViewModels.Post;
using System.Threading.Tasks;

namespace MySimpleBlog.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            //fix userId
            var userId = this.User.Identity.Name;

            var result = await this.postService.CreateAsync(model, userId);

            if (result.Failure)
            {
                return this.BadRequest("problem");
            }

            return this.Ok("super");
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditPostViewModel viewModel)
        {
            var result = await this.postService.EditAsync(viewModel);

            if (result.Failure)
            {
                return this.BadRequest("problem");
            }

            return this.Ok("super");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string postId)
        {
            var result = await this.postService.DeleteAsync(postId);

            if (result.Failure)
            {
                return this.BadRequest("problem");
            }

            return this.Ok("super");
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<Post> GetById(string id)
        => await this.postService.GetByIdAsync(id);
    }
}
