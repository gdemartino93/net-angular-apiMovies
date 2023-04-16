using net_angular_apiMovies.Models.Domain;

namespace net_angular_apiMovies.Repositories.Abstract
{
    public interface IMovieRepository
    {
        bool AddUpdate(Movie movie);
        bool Delete(int id);
        Movie GetById(int id);
        IEnumerable<Movie> GetAll();
    }
}
