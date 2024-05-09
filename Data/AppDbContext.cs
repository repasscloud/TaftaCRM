using Microsoft.EntityFrameworkCore;
using TaftaCRM.Models.Internal.System;

namespace TaftaCRM.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> Options)
        : base(Options)
    {
    }

    // internal.system
    public DbSet<UserAccount> UsersAccounts { get; set; }
}