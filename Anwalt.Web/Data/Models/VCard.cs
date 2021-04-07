// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System;
using System.Text;

namespace Anwalt.Web.Data.Models
{
    public class VCard
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string Organization { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string HomePage { get; set; }

        public byte[] Image { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .AppendLine("BEGIN:VCARD");
            builder
                .AppendLine("VERSION:2.1");

            builder
                .Append("N:")
                .Append(LastName)
                .Append(";")
                .AppendLine(FirstName);

            builder
                .Append("FN:")
                .Append(FirstName)
                .Append(" ")
                .AppendLine(LastName);

            builder
                .Append("ADR;HOME;PREF:;;")
                .Append(Street)
                .Append(";")
                .Append(City)
                .Append(";")
                .Append(PostalCode)
                .Append(";")
                .AppendLine(Country);

            builder
                .Append("ORG:")
                .AppendLine(Organization);

            builder
                .Append("TITLE")
                .AppendLine(JobTitle);

            builder
                .Append("TEL;WORK;VOICE:")
                .AppendLine(Phone);

            builder
                .Append("TEL;CELL;VOICE:")
                .AppendLine(Mobile);

            builder
                .Append("URL:")
                .AppendLine(HomePage);

            builder
                .Append("EMAIL;PREF;INTERNET:")
                .AppendLine(Email);

            if (Image != null)
            {
                builder.AppendLine("PHOTO;ENCODING=BASE64;TYPE=JPEG:");
                builder.AppendLine(Convert.ToBase64String(Image));
                builder.AppendLine(string.Empty);
            }

            builder.AppendLine("END:VCARD");

            return builder.ToString();
        }
    }
}