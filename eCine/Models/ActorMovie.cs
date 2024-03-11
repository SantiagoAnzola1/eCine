using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eCine.Models
{
    public class ActorMovie
    {

        public int MovieId { get; set; }
        public NewMovieModel Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
