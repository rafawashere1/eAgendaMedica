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

            Log.Logger.Information($"[Módulo de {endpointName}] -> Tentando {moduleName}...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                Log.Logger.Information($"[Módulo de {moduleName}] -> {endpointName} executado com sucesso");
            }
            else if (context.Exception != null)
            {
                Log.Logger.Error($"[Módulo de {moduleName}] -> Falha ao executar {endpointName}");
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

            foreach (Match m in matches)
                separatedMethodName += m.Value + " ";

            return separatedMethodName;
        }
    }
}
