using MySimpleBlog.Data.Models;
namespace MySimpleBlog.Data
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
