namespace MySimpleBlog.Data.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Posts = new HashSet<Post>();
        }

        public IEnumerable<Post> Posts { get; set; }
    }
}
