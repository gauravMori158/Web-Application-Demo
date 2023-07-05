using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Interface
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);

        void DeleteCategory(int id);
        void EditCategory(Category  category);
        void AddCategory(Category category);
    }
}
