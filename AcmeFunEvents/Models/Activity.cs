using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AcmeFunEvents.Models
{
    public partial class Activity
    {
        public Activity()
        {
            UserActivity = new HashSet<UserActivity>();
            Users = new HashSet<Users>();
        }

        public int ActivityId { get; set; }
        public string Name { get; set; }
        [DisplayName("Fitness Level Needed")]
        public string FitnessLevel { get; set; }

        public virtual ICollection<UserActivity> UserActivity { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
