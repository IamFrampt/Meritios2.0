using Meritios2._0.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meritios2._0.Data;

public class UserDbContext:DbContext
{
    public UserDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> _users { get; set; }

        
}
