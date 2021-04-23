using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WebScraper.Builders;
using WebScraper.Data;
using WebScraper.Workers;

namespace WebScraper
{
    class Program
    {
        private const string Method = "search";
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter the city:");
            var craigslistCity = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Please enter the Craigslist category you would like to search:");
            var craigslistCategory = Console.ReadLine() ?? string.Empty;

            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString($"http://{craigslistCity.Replace(" ", string.Empty)}.craigslist.org/d/{craigslistCategory.Replace(" ", "-")}/{Method}");

                ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                    .WithData(content)
                    .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"" id=\""(.*?)\>(.*?)</a>")
                    .WithRegexOption(RegexOptions.ExplicitCapture)
                    .WithPart(new ScrapeCriteriaPartBuilder()
                        .WithRegex(@">(.*?)</a>")
                        .WithRegexOption(RegexOptions.Singleline)
                        .Build())
                    .WithPart(new ScrapeCriteriaPartBuilder()
                        .WithRegex(@"href=\""(.*?)\""")
                        .WithRegexOption(RegexOptions.Singleline)
                        .Build())
                    .Build();
                Console.WriteLine(content);

                Scraper scraper = new Scraper();

                var scrapedElements = scraper.Scrape(scrapeCriteria);

                if (scrapedElements.Any())
                {
                    foreach(var scrapedElement in scrapedElements) Console.WriteLine(scrapedElement);
                }
                else
                {
                    Console.WriteLine("There were no matches for the specified scrape criteria");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
            
        }

    }
}
