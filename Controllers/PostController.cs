using Microsoft.AspNetCore.Mvc;

namespace MySimpleBlog.Controllers
{
    public class PostController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            return null;
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit()
        {
            return null;
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete()
        {
            return null;
        }

        [HttpPost]
        [Route("GetById")]
        public IActionResult GetById(string id)
        {
            return null;
        }
    }
}
