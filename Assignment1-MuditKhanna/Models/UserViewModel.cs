using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1_MuditKhanna.Models
{
    [NotMapped]
    public class UserViewModel
    {
        public List<IdentityUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public Dictionary<string, IList<string>> UserRoles { get; set; } = new Dictionary<string, IList<string>>();
    }
}
