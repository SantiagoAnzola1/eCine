using eCine.Data.Base;
using eCine.Models;

namespace eCine.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<NewMovieModel>
    {
        Task<NewMovieModel> GetMovieByIdAsync(int id);
    }
}
