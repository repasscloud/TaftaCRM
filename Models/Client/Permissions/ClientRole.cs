using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaftaCRM.Models.Client.Permissions;

[Table("ClientRoles")]
public class ClientRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    // navigation property for permissions
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
}