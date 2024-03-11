using eCine.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCine.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Logo is required")]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Relation
        public List<NewMovieModel> Movies { get; set; }
    }
}
