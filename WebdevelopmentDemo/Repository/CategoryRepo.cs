using Microsoft.EntityFrameworkCore;
using WebdevelopmentDemo.Interface;
using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ILogger<ProductRepo> _logger;
        private readonly DbContextClass _dbContext;

        public CategoryRepo(ILogger<ProductRepo> logger, DbContextClass dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }

        }

        public void EditCategory(Category category)
        {
            var cat = _dbContext.Products.Find(category.Id);
            if (cat != null)
            {
                cat.Name = category.Name;
              
                
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }
    }
}
