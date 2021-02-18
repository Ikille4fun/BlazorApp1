using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared.Components.Models.Account
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public object VerifiedSession { get; set; }


    }
}
