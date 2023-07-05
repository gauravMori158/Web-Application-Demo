using WebdevelopmentDemo.Interface;
using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ILogger<ProductRepo> _logger;
        private readonly DbContextClass _dbContext;

        public OrderRepo(ILogger<ProductRepo> logger, DbContextClass dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(p => p.Id == id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }

        }

        public void EditOrder(Order order)
        {
            var orders = _dbContext.Orders.Find(order.Id);
            if (orders != null)
            {
                orders.CustomerName = order.CustomerName;
                orders.OrderDate = order.OrderDate;


                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.Find(id);
        }
    }
}
