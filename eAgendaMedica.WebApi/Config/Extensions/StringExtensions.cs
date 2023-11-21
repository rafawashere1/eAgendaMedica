using System.Text.RegularExpressions;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class StringExtensions
    {
        public static string SeparateWordsByUppercase(this string methodName)
        {
            string regex = @"([A-Z][a-z]*)";

            MatchCollection matches = Regex.Matches(methodName, regex);

            string separatedMethodName = "";

            foreach (Match m in matches.Cast<Match>())
                separatedMethodName += m.Value + " ";

            return separatedMethodName;
        }
    }
}
