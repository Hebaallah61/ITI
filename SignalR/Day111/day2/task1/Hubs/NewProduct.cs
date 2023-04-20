using Microsoft.AspNetCore.SignalR;
using task1.Models;

namespace task1.Hubs
{
    public class NewProduct:Hub
    {
        public void AddNEWPro(Product pro)
        {
            Clients.All.SendAsync("NotifyNewProduct", pro);
        }
    }
}
