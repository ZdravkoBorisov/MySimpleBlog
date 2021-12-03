namespace MySimpleBlog.Data.Models
{
    using System;

    public class Post : BaseModel
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
