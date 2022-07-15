using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace IdentityApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required , Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required , Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
