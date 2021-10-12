using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExtendIdentityUserRole.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<CustomUserRole> Roles = new List<CustomUserRole>();
    }

    public class CustomRole : IdentityRole<string>
    {
        public ICollection<CustomUserRole> Users = new List<CustomUserRole>();
    }

    public class CustomUserRole : IdentityUserRole<string>
    {
        public string CustomProperty { get; set; } = string.Empty;

		public int CompanyId { get; set; }
		public virtual Company? Company { get; set; }

        public virtual ApplicationUser? User { get; set; }
        public virtual CustomRole? Role { get; set; }
    }

	public class Company
	{
		public int CompanyId { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}
