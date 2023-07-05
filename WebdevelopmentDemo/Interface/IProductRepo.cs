using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Interface
{
    public interface IProductRepo 
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);

        void DeleteProduct(int id);
        void EditProduct(Product product);
        void AddProduct(Product product);

    }
}
