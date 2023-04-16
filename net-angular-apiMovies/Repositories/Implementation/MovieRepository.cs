using net_angular_apiMovies.Models.Domain;
using net_angular_apiMovies.Repositories.Abstract;

namespace net_angular_apiMovies.Repositories.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext _ctx;

        public MovieRepository(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }

        public bool AddUpdate(Movie movie)
        {
            try
            {
                if(movie.Id == 0)
                {
                    _ctx.Movies.Add(movie);
                }
                else
                {
                    _ctx.Movies.Update(movie);
                }
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var movieSearched = GetById(id);
                if(movieSearched == null)
                {
                    return false;
                }
                _ctx.Movies.Remove(movieSearched);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Movie> GetAll(string term)
        {
           term = term.ToLower(); //convertiamo in minuscolo la parola cercata
           var data = (from movie in _ctx.Movies
                       join
                       category in _ctx.Categories
                       on movie.Id equals category.Id
                       where term == "" || movie.Title.StartsWith(term)).ToList();
            return data;
        }

        public Movie GetById(int id)
        {
            return _ctx.Movies.Find(id);
        }
    }
}
