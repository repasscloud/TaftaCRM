using Microsoft.EntityFrameworkCore;
using TaftaCRM.Models.Client.Permissions;
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

    // client.permissions
    public DbSet<ClientRole> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // seed a default client role
        var defaultRodeId = 1;
        modelBuilder.Entity<ClientRole>().HasData(
            new ClientRole
            {
                Id = defaultRodeId,
                RoleName = "Admin",
                Permissions = Models.Client.Permissions.Enums.PermissionType.READ | 
                    Models.Client.Permissions.Enums.PermissionType.WRITE |
                    Models.Client.Permissions.Enums.PermissionType.CREATE |
                    Models.Client.Permissions.Enums.PermissionType.DELETE,
            }
        );

        // seed a default user
        modelBuilder.Entity<UserAccount>().HasData(
            new UserAccount
            {
                Id = 1,
                EmailAddress = "admin@taftacrm.com",
                Password = "9mssKi>£4zpx?TY]@_i1.Wf8lFA9;",
                userAccountRole = Models.Internal.System.Static.UserAccountRole.sudo,
                userAccountStatus = Models.Internal.System.Static.UserAccountStatus.Enabled,
                userAccountCreated = DateTime.UtcNow,
                EmailVerified = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ClientRoleId = defaultRodeId,
            }
        );
    }
}
