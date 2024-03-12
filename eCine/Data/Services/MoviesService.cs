using eCine.Data.Base;
using eCine.Data.ViewModels;
using eCine.Models;
using Microsoft.EntityFrameworkCore;
using eCine.Models;
namespace eCine.Data.Services
{
    public class MoviesService : EntityBaseRepository<NewMovieModel>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context=context;
        }

        public async Task AddNewMovieAsync(NewMovieM data)
        {
            var movie = new NewMovieModel()
            {
                Name = data.Name,
                Decription = data.Description,
                Price = data.Price,
                Image = data.Image,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,

            };
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            //Add Movie Actors

            foreach(var actorId in data.ActorsId)
            {
                var actorMovie = new ActorMovie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                await _context.ActorsMovies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewMovieModel> GetMovieByIdAsync(int id)
        {
            var movie =await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.ActorsMovies).ThenInclude(a=>a.Actor)
                .FirstOrDefaultAsync(n=>n.Id==id);

            return movie;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {

                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateMovieAsync(NewMovieM data)
        {
            var dbMovie=await _context.Movies.FirstOrDefaultAsync(n=>n.Id== data.Id);
            if (dbMovie != null)
            {

                dbMovie.Name = data.Name;
                dbMovie.Decription = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.Image = data.Image;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }
            //Remove existing actors
            var existingActorsDb=_context.ActorsMovies.Where(n=>n.MovieId== data.Id).ToList();
            _context.ActorsMovies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors

            foreach (var actorId in data.ActorsId)
            {
                var actorMovie = new ActorMovie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.ActorsMovies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
