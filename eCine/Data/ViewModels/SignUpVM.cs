using System.ComponentModel.DataAnnotations;

namespace eCine.Data.ViewModels
{
    public class SignUpVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required (ErrorMessage = "Confirmation password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
