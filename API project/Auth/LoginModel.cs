using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;

namespace api_project.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; } = string.Empty;
    }
}
