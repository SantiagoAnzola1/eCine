using eCine.Data.Base;
using eCine.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCine.Models
{
    public class NewMovieM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Movie name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price ($)")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Display(Name = "Movie Image URL")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie category is required")]
        [Display(Name = "Select a movie category")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Movie actor(s) is required")]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorsId { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        [Display(Name = "Select a Cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Movie producer is required")]
        [Display(Name = "Select a producer")]
        public int ProducerId { get; set; }


    }
}
