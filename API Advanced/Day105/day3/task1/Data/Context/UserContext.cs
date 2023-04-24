using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task1.Data.Models;

namespace task1.Data.Context;

public class UserContext:IdentityDbContext<User>
{
    public UserContext(DbContextOptions<UserContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        
    }
}
