using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaftaCRM.Models.Client.Permissions.Enums;
using TaftaCRM.Models.Internal.System;

namespace TaftaCRM.Models.Client.Permissions;

[Table("client_roles")]
public class ClientRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("role_name")]
    [MaxLength(100)]
    public string RoleName { get; set; } = null!;

    // Store the combined permissions
    [Column("permissions")]
    public PermissionType Permissions { get; set; } = PermissionType.NONE;

    // Navigation property for the related user accounts
    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
