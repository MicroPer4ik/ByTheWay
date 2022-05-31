namespace BlazorServer.Models.Interfaces
{
    public interface IBidService
    {
        List<Bid> Bids { get; set; }
        Task LoadBids();
        Task<Bid> GetSingleBid(int id);
        Task CreateBid (Bid bid);
        Task UpdateBid (Bid bid, int id);
        Task DeleteBid (int id);
    }
}
