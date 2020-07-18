using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Common;

namespace Entities.User
{
    public class User : BaseEntity
    {
        public User()
        {
            IsActive = true;
        }

        [Required] [StringLength(100)] public string UserName { get; set; }
        [Required] [StringLength(500)] public string PasswordHash { get; set; }
        [Required] [StringLength(100)] public string FullName { get; set; }
        public GenderType Age { get; set; }
        public int Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }

        public ICollection<Post.Post> Posts { get; set; }
    }

    public enum GenderType
    {
        [Display(Name = "Man")] Male = 1,
        [Display(Name = "Woman")] Female = 2
    }
}