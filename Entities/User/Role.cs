using System.ComponentModel.DataAnnotations;
using Entities.Common;

namespace Entities.User
{
    public class Role : BaseEntity
    {
        [Required] [StringLength(50)] public string Name { get; set; }
        public string Description { get; set; }
    }
}