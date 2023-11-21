using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Text.RegularExpressions;

namespace eAgenda.WebApi.Filters
{
    public class SerilogActionFilter : IActionFilter
    {
        private object endpointName;
        private object moduleName;


        public void OnActionExecuting(ActionExecutingContext context)
        {
            endpointName = context.RouteData.Values["action"]!
                .ToString()!.SeparateWordsByUppercase();

            moduleName = context.RouteData.Values["controller"];

            Log.Logger.Information($"[Module {endpointName}] -> Trying {moduleName}...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                Log.Logger.Information($"[Module {moduleName}] -> {endpointName} executed successfully");
            }
            else if (context.Exception != null)
            {
                Log.Logger.Error($"[Module {moduleName}] -> Failed to execute {endpointName}");
            }
        }
    }

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
