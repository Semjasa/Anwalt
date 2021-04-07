// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Anwalt.Web.Features.Identity.Models
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordRepeat { get; set; }
    }
}