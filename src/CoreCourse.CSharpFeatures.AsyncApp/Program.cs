using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.CSharpFeatures.AsyncApp
{
    class Program
    {
        static SiteChecker sitechecker = new SiteChecker();

        static void Main(string[] args)
        {
            //immediate initialization
            var siteDefinitions = new[]
            {
                new { Url = "http://www.google.com", Rating=90 },
                new { Url = "https://www.stackoverflow.com", Rating=80 },
                new { Url = "https://www.codeproject.com", Rating=75 },
                new { Url = "http://www.deredactie.be", Rating=70 },
                new { Url = "http://www.svt.se", Rating=70 },
                new { Url = "https://www.github.com", Rating=75 },
            };

            Console.WriteLine($"Checking {siteDefinitions.Length} sites...\r\n");

            //check sites
            Task checkTask = CheckSites(siteDefinitions.Select(e => e.Url));

            //calculate average while checking sites
            var averageRating = sitechecker.AverageRating(siteDefinitions.Select(sd => sd.Rating));
            Console.WriteLine($"\r\nAverage rating: {averageRating:N2}\r\n");

            //wait for task to finish
            checkTask.Wait();

            //prevent quitting in debug mode
            Console.WriteLine($"\r\nPress any key to exit");
            Console.Read();
        }

        static async Task CheckSites(IEnumerable<string> urls)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            //check sites
            foreach (var url in urls)
            {
                var status = await sitechecker.GetStatusCode(url);
                if (status != 200)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{url} status: {status}");
                Console.ForegroundColor = defaultColor;
            }
        }

    }
}