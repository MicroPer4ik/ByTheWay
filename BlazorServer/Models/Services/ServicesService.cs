using BlazorServer.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Models.Services
{
    public class ServicesService : IServicesService
    {
        private readonly CleaningDbContext _context;
        private readonly NavigationManager _navigationManager;

        public ServicesService(CleaningDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Service> Services { get; set; } = new List<Service>();

        public async Task CreateService(Service service)
        {
            try
            {
                //service.Id = 4;
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                _navigationManager.NavigateTo("serviceview");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                throw new Exception("Нет сервиса. :/");
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("serviceview");
        }

        public async Task<Service> GetSingleService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if(service == null)
            {
                throw new Exception("Нет сервиса. :/");
            }
            return service;
        }

        public async Task LoadService()
        {
            Services = await _context.Services.ToListAsync();
        }

        public async Task UpdateService(Service service, int id)
        {
            var dbService = await _context.Services.FindAsync(id);
            if(dbService == null)
            {
                throw new Exception("Нет сервиса. :/");
            }
            dbService.TitleService = service.TitleService;
            dbService.CostService = service.CostService;
            dbService.DescriptionService = service.DescriptionService;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("serviceview");

        }
    }
}
