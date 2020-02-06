using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatziBadges.Entity
{
    [Table("Badge")]
    public class Badge : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string JobTitle { get; set; }
        [MaxLength(50)]
        public string Twitter { get; set; }
        [MaxLength(300)]
        public string AvatarUrl { get; set; }
    }
}
