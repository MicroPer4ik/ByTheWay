namespace BlazorServer.Models.Interfaces
{
    public interface IClientService
    {
        List<Client> Clients { get; set; }
        Task LoadClients();
        Task<Client> GetSingleClient(int id);
        Task CreateClient(Client client);
        Task UpdateClient(Client client, int id);
        Task DeleteClient(int id);
    }
}
