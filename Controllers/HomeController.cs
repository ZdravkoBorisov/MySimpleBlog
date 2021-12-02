namespace MySimpleBlog.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("GetRecentPosts")]
        public IActionResult GetRecentPosts()
        {
            return null;
        }
    }
}
