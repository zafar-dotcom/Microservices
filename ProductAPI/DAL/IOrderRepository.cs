using ProductAPI.Model;

namespace ProductAPI.DAL
{
    public interface IOrderRepository
    {
        Task<int> Add(Order order);
        Task<Order> GetById(int id);
        Task<string> Cancel(int id);
        Task<Order> GetByCustomerId(int customerId);
    }
}
