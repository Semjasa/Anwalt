// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

namespace Anwalt.Web.Data
{
    public class Validation
    {
        public class User
        {
            public const int MaxFirstNameLength = 25;

            public const int MaxMiddleNameLength = 25;

            public const int MaxLastNameLength = 25;

            public const int MaxPostalCodeLength = 5;
        }

        public class Home
        {
            public const int MaxHeadlineLength = 60;

            public const int MaxCardHeadlineLength = 2;
        }
    }
}