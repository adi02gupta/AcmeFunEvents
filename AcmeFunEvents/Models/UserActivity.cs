// Author : Aditya Gupta
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AcmeFunEvents.Models
{
    public partial class UserActivity
    {
        public UserActivity()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone, if provided muste be 10 digits: 123-123-1234")]
        public string Phone { get; set; }
        [Required]
        public int? ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
