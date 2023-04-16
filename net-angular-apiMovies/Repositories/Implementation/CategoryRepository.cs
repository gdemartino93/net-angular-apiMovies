using Microsoft.EntityFrameworkCore;
using net_angular_apiMovies.Models.Domain;
using net_angular_apiMovies.Repositories.Abstract;

namespace net_angular_apiMovies.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _ctx;

        public CategoryRepository(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public bool AddUpdate(Category category)
        {
            try
            {
                if(category.Id == 0)
                {
                    _ctx.Add(category);
                }
                else
                {
                    _ctx.Update(category);
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
                var categorySearched = _ctx.Categories.Find(id);
                if (categorySearched == null)
                {
                    return false;
                }
                _ctx.Remove(categorySearched);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _ctx.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _ctx.Categories.Include(c => c.Movies).FirstOrDefault(c => c.Id == id);
        }

    }
}
