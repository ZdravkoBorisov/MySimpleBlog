namespace MySimpleBlog.Data.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
