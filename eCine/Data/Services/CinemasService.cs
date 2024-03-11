using eCine.Data.Base;
using eCine.Models;

namespace eCine.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context):base(context)
        {
            
        }
    }
}
