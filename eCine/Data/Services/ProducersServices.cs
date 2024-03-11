using eCine.Data.Base;
using eCine.Models;

namespace eCine.Data.Services
{
    public class ProducersServices:EntityBaseRepository<Producer>, IProducersService
    {

        public ProducersServices(AppDbContext context):base(context)
        {
            
        }
    }
}
