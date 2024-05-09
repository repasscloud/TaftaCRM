using System.ComponentModel.DataAnnotations;

namespace TaftaCRM.Models.ViewModels;

public class RegisterViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Provide email address")]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
    public string? UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters long")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirm password is required")]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string? PasswordConfirm { get; set; }
}