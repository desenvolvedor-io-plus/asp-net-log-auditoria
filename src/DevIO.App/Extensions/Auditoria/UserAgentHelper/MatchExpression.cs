using System.Text.RegularExpressions;

namespace DevIO.App.Extensions.Auditoria.UserAgentHelper
{
    public class MatchExpression
    {
        public List<Regex> Regexes { get; set; }

        public Action<Match, object> Action { get; set; }
    }
}