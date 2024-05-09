using System.ComponentModel.DataAnnotations;

namespace TaftaCRM.Models.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Email address")]
    public string? UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Password")]
    public string? Password { get; set; }
}