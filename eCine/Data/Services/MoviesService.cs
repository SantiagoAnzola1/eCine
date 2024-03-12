using eCine.Data.Base;
using eCine.Data.ViewModels;
using eCine.Models;
using Microsoft.EntityFrameworkCore;

namespace eCine.Data.Services
{
    public class MoviesService : EntityBaseRepository<NewMovieModel>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context=context;
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
    }
}
