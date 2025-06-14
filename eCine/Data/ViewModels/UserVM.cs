using eCine.Data.Static;
using System.ComponentModel.DataAnnotations;

namespace eCine.Data.ViewModels
{
   
    public class UserVM
    {
        public string Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public List<string> Roles { get; set; } = UserRoles.Roles.ToList(); // Available roles for selection  
   
    }
}
