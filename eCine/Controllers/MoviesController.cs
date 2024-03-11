using eCine.Data;
using eCine.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCine.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n=>n.Cinema);
            //.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync()
            return View(allMovies);
        }

        public async Task<IActionResult> Info(int id )
        {
            var movie = await _service.GetMovieByIdAsync(id);
            return View(movie);
        }

        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome";
            return View();
        }
        public IActionResult Forms()
        {
            ViewData["Welcome"] = "Welcome";
            return View();
        }
    }
}
