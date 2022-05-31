using BlazorServer.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Models.Services
{
    public class BidService : IBidService
    {
        private readonly CleaningDbContext _context;
        private readonly NavigationManager _navigationManager;
        public BidService(CleaningDbContext context, NavigationManager navigationManager)
        {
            _context = context; 
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Bid> Bids { get; set; } = new List<Bid>();

        public async Task CreateBid(Bid bid)
        {
            try
            {
                _context.Bids.Add(bid);
                await _context.SaveChangesAsync();
                _navigationManager.NavigateTo("");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteBid(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid == null)
            {
                throw new Exception("Нет заявки. :/");
            }

            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("");
        }

        public async Task<Bid> GetSingleBid(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid == null)
            {
                throw new Exception("Нет заявки. :/");
            }
            return bid;
        }

        public async Task LoadBids()
        {
            Bids = await _context.Bids.ToListAsync();
        }

        public async Task UpdateBid(Bid bid, int id)
        {
            var dbBid = await _context.Bids.FindAsync(id);
            if (dbBid == null)
            {
                throw new Exception("Нет сервиса. :/");
            }
            dbBid.IdClient = bid.IdClient;
            dbBid.DateSubmission = bid.DateSubmission;
            dbBid.IdStatus = bid.IdStatus;
            dbBid.Description = bid.Description;


            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("clientslist");
        }
    }
}
