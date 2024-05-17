using Microsoft.EntityFrameworkCore;
using TaftaCRM.Models.Client.Permissions;
using TaftaCRM.Models.Client.Permissions.Enums;
using TaftaCRM.Models.Internal.System;
using TaftaCRM.Models.Internal.System.Static;

namespace TaftaCRM.Data
{
    public class TaftaDbContext : DbContext
    {
        public TaftaDbContext(DbContextOptions<TaftaDbContext> options)
            : base(options)
        {
        }

        // internal.system
        public DbSet<UserAccount> UsersAccounts { get; set; }

        // client.permissions
        public DbSet<ClientRole> ClientRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed a default role
            var defaultRoleId = 1;
            modelBuilder.Entity<ClientRole>().HasData(
                new ClientRole
                {
                    Id = defaultRoleId,
                    RoleName = "Admin",
                    Permissions = PermissionType.READ | PermissionType.WRITE | PermissionType.CREATE | PermissionType.DELETE
                }
            );

            // Seed a default user
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    Id = 1,
                    EmailAddress = "admin@taftacrm.com",
                    Password = "9mssKi>£4zpx?TY]@_i1.Wf8lFA9;", // Ensure you hash passwords in real applications
                    userAccountRole = UserAccountRole.Administrator,
                    userAccountStatus = UserAccountStatus.Enabled,
                    userAccountCreated = DateTime.UtcNow,
                    EmailVerified = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ClientRoleId = defaultRoleId
                }
            );
        }
    }
}
