namespace MySimpleBlog.Data.Models
{
    using System;

    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
