using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaftaCRM.Models.Client.Permissions;
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
    public UserAccountRole userAccountRole { get; set; } = UserAccountRole.Guest;

    [Column("status")]
    public UserAccountStatus userAccountStatus { get; set; } = UserAccountStatus.Disabled;

    [Column("created")]
    public DateTime userAccountCreated { get; set; } = DateTime.UtcNow;

    [Column("expires")]
    public DateTime? userAccountExpiration { get; set; }

    [Column("last_login")]
    public DateTime? LastLoginDate { get; set; }

    [Column("email_verified")]
    public bool EmailVerified { get; set; } = false;

    [Column("failed_login_attempts")]
    public int FailedLoginAttempts { get; set; } = 0;

    [Column("security_stamp")]
    public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();

    [Column("two_factor_enabled")]
    public bool TwoFactorEnabled { get; set; } = false;

    [Column("phone_number")]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    [Column("phone_number_verified")]
    public bool PhoneNumberVerified { get; set; } = false;

    // Foreign key to ClientRole
    [ForeignKey("ClientRoleId")]
    public int? ClientRoleId { get; set; }

    public virtual ClientRole? ClientRole { get; set; }
}
