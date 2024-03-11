using eCine.Data.Base;
using eCine.Models;
using Microsoft.EntityFrameworkCore;

namespace eCine.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context):base (context) 
        {
        }
        //public async Task AddAsync(Actor actor)
        //{
        //    await _context.Actors.AddAsync(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var actor = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //    _context.Actors.Remove(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Actor>> GetAllAsync()
        //{
        //    var result =await _context.Actors.ToListAsync();
        //    return result;
        //}

        //public async Task<Actor> GetByIdAsync(int id)
        //{
        //    var actor =await _context.Actors.FirstOrDefaultAsync(n=> n.Id==id);
        //    return actor;
        //}

        //public async Task<Actor> UpddateAsync(int id, Actor actor)
        //{
        //    _context.Actors.Update(actor);
        //    await _context.SaveChangesAsync();
        //    return actor;
        //}
    }
}
