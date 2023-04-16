using System.ComponentModel.DataAnnotations;

namespace net_angular_apiMovies.Models.Domain
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
