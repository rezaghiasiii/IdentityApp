using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.ViewModels.Account;

public class RegisterViewModel
{
    [Required]
    [Display(Name = "نام کاربری")]
    [Remote("IsUserNameInUse", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "ایمیل")]
    [EmailAddress]
    [Remote("IsEmailInUse", "Account",HttpMethod = "POST",AdditionalFields = "__RequestVerificationToken")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "رمز عبور")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "تکرار رمز عبور")]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}