using eCine.Data.Base;
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
    }
}
