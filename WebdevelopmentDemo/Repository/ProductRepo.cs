using Microsoft.EntityFrameworkCore;
using WebdevelopmentDemo.Interface;
using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ILogger<ProductRepo> _logger;
        private readonly DbContextClass _dbContext;

        public ProductRepo(ILogger<ProductRepo> logger , DbContextClass dbContext)
        {
                _logger = logger;
              _dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
           var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }

        }

        public void EditProduct(Product product)
        {
            var product1 = _dbContext.Products.Find(product.Id);
            if (product1 != null)
            {
                product1.Name = product.Name;
                product1.Price= product.Price;
                product1.CategoryId = product.CategoryId;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
           return _dbContext.Products.Include(p => p.Category).ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }
    }
}
