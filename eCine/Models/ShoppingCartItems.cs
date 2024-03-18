using System.ComponentModel.DataAnnotations;

namespace eCine.Models
{
    public class ShoppingCartItems
    {
        [Key]
        public int Id { get; set; }
        public NewMovieModel Movie { get; set; }
        public int Amount { get; set; }
        

        public string ShoppingCartId { get; set; }
    }
}
