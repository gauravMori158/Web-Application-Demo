using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Interface
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);

        void DeleteOrder(int id);
        void EditOrder(Order order);
        void AddOrder(Order order);
    }
}
