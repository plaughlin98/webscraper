using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace WebScraper.Data
{
    public class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }
    

        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption {get; set;}
        public List<ScrapeCriteriaPart> Parts { get; set; }
    }
}