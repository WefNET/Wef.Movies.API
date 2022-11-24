using System.ComponentModel.DataAnnotations;

namespace Wef.Movies.API.Domain
{
    public class MovieRatings
    {
        [Key]
        public int RatingId { get; set; }
        public int Stars { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
