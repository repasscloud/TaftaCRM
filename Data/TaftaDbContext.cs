using Microsoft.EntityFrameworkCore;
using TaftaCRM.Models.Internal.System;

namespace TaftaCRM.Data;

public class TaftaDbContext : DbContext
{
    public TaftaDbContext(DbContextOptions<TaftaDbContext> Options)
        : base(Options)
    {
    }

    // internal.system
    public DbSet<UserAccount> UsersAccounts { get; set; }
}