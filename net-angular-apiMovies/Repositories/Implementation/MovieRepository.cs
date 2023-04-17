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
            term = term.ToLower();
            var data = (from movie in _ctx.Movies
                        join category in _ctx.Categories
                        on movie.CategoryId equals category.Id
                        where term == "" || movie.Title.StartsWith(term)
                        select new Movie
                        {
                            Id = movie.Id,
                            Title = movie.Title,
                            CategoryId = movie.CategoryId,
                            Description = movie.Description,
                            Vote = movie.Vote,
                            CategoryName = category.Name 
                        }).ToList();
            return data;
        }


        public Movie GetById(int id)
        {
            var movie = (from m in _ctx.Movies
                         where m.Id == id
                         join c in _ctx.Categories on m.CategoryId equals c.Id
                         select new Movie
                         {
                             Id = m.Id,
                             Title = m.Title,
                             CategoryId = c.Id,
                             CategoryName = c.Name,
                             Description = m.Description,
                             Vote = m.Vote,
                         }).FirstOrDefault();

            return movie;
        }
    }
}
