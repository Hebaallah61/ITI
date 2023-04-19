using Microsoft.AspNetCore.SignalR;
using task1.Models;
using task1.MyDB;

namespace task1.Hubs
{
    public class Comments:Hub
    {
        private readonly MyDBContext _dbContext;

        public Comments(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task NewComment(string userName, string text,int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                var comment = new Comment
                {
                    Username = userName,
                    text = text,
                    Product = product
                };
                _dbContext.Comments.Add(comment);
                await _dbContext.SaveChangesAsync();
            }
            await Clients.All.SendAsync("NotifyAll",userName,text,id);
        }
    }
}
