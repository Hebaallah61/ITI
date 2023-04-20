using Microsoft.AspNetCore.SignalR;
using task1.MyDB;

namespace task1.Hubs
{
    public class Buy : Hub
    {
        private readonly MyDBContext _dbContext;

        public Buy(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task NewBuy(int id, int quantity)
        {
            var product = await _dbContext.Products.FindAsync(id);
            product.quentity--;
            await _dbContext.SaveChangesAsync();

            await Clients.All.SendAsync("NotifyAllquantity", id, product.quentity);
        }
    }
}