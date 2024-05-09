using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaftaCRM.Models.Internal.System.Static;

namespace TaftaCRM.Models.Internal.System;

[Table("user_accounts")]
public class UserAccount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("user_name")]
    [MaxLength(100)]
    public string EmailAddress { get; set; } = null!;

    [Column("password")]
    [MaxLength(100)]
    public string Password { get; set; } = null!;

    [Column("role")]
    public UserAccountRole userAccountRole { get; set; } = UserAccountRole.Pleb;

    [Column("status")]
    public UserAccountStatus userAccountStatus{ get; set; } = UserAccountStatus.Disabled;
}