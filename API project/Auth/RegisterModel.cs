using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace api_project.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; } = string.Empty;
    }
}
