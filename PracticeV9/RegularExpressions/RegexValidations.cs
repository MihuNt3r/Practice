using System.Text.RegularExpressions;

namespace PracticeV9.RegularExpressions
{
    public class RegexValidations
    {
        public static Regex NameValidator = new Regex("([A-Z][-,a-z. ']+[ ]*)+$");
        public static Regex CityValidator = new Regex(@"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$");
    }
}
