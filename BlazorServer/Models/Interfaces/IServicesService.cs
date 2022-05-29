namespace BlazorServer.Models.Interfaces
{
    public interface IServicesService
    {
        List<Service> Services { get; set; }
        Task LoadService();
        Task<Service> GetSingleService(int id);
        Task CreateService(Service service);
        Task UpdateService(Service service, int id);
        Task DeleteService(int id);
    }
}
