using Microsoft.EntityFrameworkCore;
using TaftaCRM.Models.Internal.System;

namespace TaftaCRM.Models;

public class ServerDbContext : DbContext
{
    public ServerDbContext(DbContextOptions<ServerDbContext> Options)
        : base(Options)
    {
    }

    // internal.system
    public DbSet<UserAccount> UsersAccounts { get; set; }
}