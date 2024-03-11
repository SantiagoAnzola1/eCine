using eCine.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCine.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 200 characters")]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        //Relation
        public List<NewMovieModel> Movies { get; set; }
    }
}
