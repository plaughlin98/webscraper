using System.Text.RegularExpressions;
using WebScraper.Data;

namespace WebScraper.Builders
{
    public class ScrapeCriteriaPartBuilder
    {
        // public string Regex { get; set; }
        // public RegexOptions RegexOption { get; set; }

        private string _regex;
        private RegexOptions _regexOption;

        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }
        public void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }
        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        public ScrapeCriteriaPartBuilder WithRegexOption(RegexOptions regexOptions)
        {
            _regexOption = regexOptions;
            return this;
        }

        public ScrapeCriteriaPart Build()
        {
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.RegexOption = _regexOption;
            return scrapeCriteriaPart;
        }

    }
}