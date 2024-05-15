using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaftaCRM.Models.Client.Permissions;

[Table("RolePermissions")]
public class RolePermission
{
    [Key]
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    // Navigation properties
    [ForeignKey("RoleId")]
    public virtual ClientRole Role { get; set; }

    [ForeignKey("PermissionId")]
    public virtual Permission Permission { get; set; }
}