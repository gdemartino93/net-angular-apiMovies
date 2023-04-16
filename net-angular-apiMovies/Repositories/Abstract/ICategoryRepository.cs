using net_angular_apiMovies.Models.Domain;

namespace net_angular_apiMovies.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        bool AddUpdate(Category category);
        bool Delete(int id);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
    }
}
