using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaftaCRM.Models.Client.Permissions;

[Table("Permissions")]
public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }  // E.g., "Create", "Read", "Update", "Delete"

    // Navigation property for role-permissions
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}