using eCine.Models;
using Microsoft.EntityFrameworkCore;

namespace eCine.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItems> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public List<ShoppingCartItems> GetShoppingCartItems() { 
            return ShoppingCartItems ?? (ShoppingCartItems=_context.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).Include(n=>n.Movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            return _context.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).Select(n=>n.Movie.Price*n.Amount).Sum();
            
        }
    }
}
