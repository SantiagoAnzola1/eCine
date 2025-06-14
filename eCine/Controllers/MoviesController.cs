using eCine.Data;
using eCine.Data.Services;
using eCine.Data.Static;
using eCine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                //var filterResult =allMovies.Where(n=>n.Name.Contains(searchString) || n.Decription.Contains(searchString)).ToList();

                var filterResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString) || n.Decription.ToLower().Contains(searchString)).ToList();
                return View("Index", filterResult);
            }
            return View("Index", allMovies);
        }

        public async Task<IActionResult> Info(int id )
        {
            var movie = await _service.GetMovieByIdAsync(id);
            return View(movie);
        }


        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create(NewMovieM movie)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if(movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieM()
            {
                Id=movieDetails.Id,
                Name=movieDetails.Name,
                Description=movieDetails.Decription,
                Price=movieDetails.Price,
                StartDate=movieDetails.StartDate,
                EndDate=movieDetails.EndDate,
                Image=movieDetails.Image,
                MovieCategory=movieDetails.MovieCategory,
                CinemaId=movieDetails.CinemaId,
                ProducerId=movieDetails.ProducerId,
                ActorsId=movieDetails.ActorsMovies.Select(n=>n.ActorId).ToList()
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id, NewMovieM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
        }
        public IActionResult Shop()
        {
            ViewData["Welcome"] = "Welcome";
            return View();
        }


    }
}
