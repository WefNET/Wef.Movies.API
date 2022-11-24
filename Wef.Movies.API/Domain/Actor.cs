using System.ComponentModel.DataAnnotations;

namespace Wef.Movies.API.Domain
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
