using System.ComponentModel.DataAnnotations;

namespace NSE.Identity.API.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [EmailAddress(ErrorMessage = "The {0} field is in an invalid format")]
        public string?Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string PasswordConfirmation { get; set; } = string.Empty;
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [EmailAddress(ErrorMessage = "The {0} field is in an invalid format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }

    public class UserResponseLogin
    {
        public string AccessToken { get; set; } = string.Empty;
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; } = new UserToken();
    }

    public class UserToken
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }

    public class UserClaim
    {
        public string Value { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
