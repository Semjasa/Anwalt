// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

using static Anwalt.Web.Data.Validation.User;

namespace Anwalt.Web.Data.Models
{
    public class Profile
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [MaxLength(MaxFirstNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxMiddleNameLength)]
        public string MiddleName { get; set; }

        [MaxLength(MaxLastNameLength)]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [DefaultValue(nameof(Models.Gender.Undefined))]
        public string Gender { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        [MaxLength(MaxPostalCodeLength)]
        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }
    }
}