using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eCine.Models
{
    public class AplicationUser:IdentityUser
    {
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
    }
}
