using System.ComponentModel.DataAnnotations;

namespace Wef.Movies.API.Domain
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public virtual ICollection<MovieRatings> Ratings { get; set; } = new List<MovieRatings>();
    }
}
