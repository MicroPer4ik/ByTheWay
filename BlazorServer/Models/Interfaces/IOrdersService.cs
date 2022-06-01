namespace BlazorServer.Models.Interfaces
{
    public interface IOrdersService
    {
        List<Order> Orders { get; set; }
        Task LoadOrders();
        Task<Order> GetSingleOrder(int id);
        Task CreateOrder(Order order, Client client);
        Task UpdateOrder(Order order, int id);
        Task DeleteOrder(int id);
    }
}
