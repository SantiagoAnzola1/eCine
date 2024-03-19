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

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session=services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context=services.GetService<AppDbContext>();
            string cartId=session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId=cartId};
        }
        public void AddItemToCart(NewMovieModel movie)
        {
            var shoppingCartItem=_context.ShoppingCartItems.FirstOrDefault(n=>n.Movie.Id == movie.Id && n.ShoppingCartId==ShoppingCartId );

            if(shoppingCartItem != null)
            {
                shoppingCartItem = new ShoppingCartItems()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(NewMovieModel movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 0) { shoppingCartItem.Amount--; } 
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

                
            }
            _context.SaveChanges();
        }
        public void RemoveCompletlyItemFromCart(NewMovieModel movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
               
                _context.ShoppingCartItems.Remove(shoppingCartItem);
   
            }
            _context.SaveChanges();
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
