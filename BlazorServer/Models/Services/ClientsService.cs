using BlazorServer.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Models.Services
{
    public class ClientsService : IClientService
    {
        private readonly CleaningDbContext _context;
        private readonly NavigationManager _navigationManager;

        public ClientsService(CleaningDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Client> Clients { get; set; } = new List<Client>();

        public async Task CreateClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                _navigationManager.NavigateTo("clientslist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new Exception("Нет клиента. :/");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("clientslist");
        }

        public async Task<Client> GetSingleClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new Exception("Нет клиента. :/");
            }
            return client;
        }

        public async Task LoadClients()
        {
            Clients = await _context.Clients.ToListAsync();
        }

        public async Task UpdateClient(Client client, int id)
        {
            var dbClient = await _context.Clients.FindAsync(id);
            if (dbClient == null)
            {
                throw new Exception("Нет сервиса. :/");
            }
            dbClient.Surname = client.Surname;
            dbClient.Name = client.Name;
            dbClient.Patronymic = client.Patronymic;
            dbClient.Address = client.Address;
            dbClient.PhoneNumber = client.PhoneNumber;
            dbClient.Email = client.Email;


            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("clientslist");
        }
    }
}
