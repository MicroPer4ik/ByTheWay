using BlazorServer.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Models.Services
{
    public class OrderService : IOrdersService
    {
        private readonly CleaningDbContext _context;
        private readonly NavigationManager _navigationManager;
        public OrderService(CleaningDbContext cleaningDbContext, NavigationManager navigationManager )
        {
            _context = cleaningDbContext; 
            _navigationManager = navigationManager;
            //_context.Database.EnsureCreated();
        }

        public List<Order> Orders {get; set;}   

        public async Task CreateOrder(Order order, Client client)
        {
            try
            {
                var dbClient = await _context.Clients.FirstOrDefaultAsync(c => c.Surname == client.Surname && c.Name == client.Name && c.Patronymic == client.Patronymic && c.Address == client.Address);
                if (dbClient != null)
                {
                    order.IdClientNavigation = dbClient;
                    await _context.Orders.AddAsync(order);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    order.IdClientNavigation = client;
                    await _context.Clients.AddAsync(client);
                    await _context.Orders.AddAsync(order);
                    await _context.SaveChangesAsync();
                }


                //_context.Orders.Add( order );
                //await _context.SaveChangesAsync();
                _navigationManager.NavigateTo("/");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order == null)
            {
                throw new Exception("Нет заказа. :/");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("");
        }

        public async Task<Order> GetSingleOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new Exception("Нет заказа. :/");
            }
            return order;
        }

        public async Task LoadOrders()
        {
            Orders = await _context.Orders.Include(o=>o.IdStatusNavigation).ToListAsync();
        }

        public async Task UpdateOrder(Order order, int id)
        {
            var dbOrder = await _context.Orders.FindAsync(id);
            if (dbOrder == null)
            {
                throw new Exception("Нет заказа. :/");
            }
            dbOrder.PriceOrder = order.PriceOrder;
            dbOrder.Employee = order.Employee;
            dbOrder.IdStatusNavigation = order.IdStatusNavigation;
            



            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("");
        }
    }
}
