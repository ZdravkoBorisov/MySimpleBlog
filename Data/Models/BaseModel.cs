namespace MySimpleBlog.Data.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [AllowNull]
        public DateTime DeletedOn { get; set; }

        [AllowNull]
        public DateTime ModifiedOn { get; set; }
    }
}
