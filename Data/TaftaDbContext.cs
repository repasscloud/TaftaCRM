using Microsoft.AspNetCore.Identity;
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
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the many-to-many relationship between Role and Permission
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);

        // Seeding the Permission table
        modelBuilder.Entity<Permission>().HasData(
            new Permission { PermissionId = 1, Name = "Create" },
            new Permission { PermissionId = 2, Name = "Read" },
            new Permission { PermissionId = 3, Name = "Update" },
            new Permission { PermissionId = 4, Name = "Delete" }
        );

        // Seeding the Role table
        modelBuilder.Entity<ClientRole>().HasData(
            new ClientRole { RoleId = 1, Name = "Administrator" }
        );

        // Seeding the RolePermission join table
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission { RoleId = 1, PermissionId = 1 },
            new RolePermission { RoleId = 1, PermissionId = 2 },
            new RolePermission { RoleId = 1, PermissionId = 3 },
            new RolePermission { RoleId = 1, PermissionId = 4 }
        );

        base.OnModelCreating(modelBuilder);
    }
}