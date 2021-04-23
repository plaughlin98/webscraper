using System.Text.RegularExpressions;

namespace WebScraper.Data
{
    internal class ScrapeCriteriaPart
    {
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
    }
}