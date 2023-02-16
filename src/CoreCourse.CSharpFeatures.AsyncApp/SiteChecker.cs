using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreCourse.CSharpFeatures.AsyncApp
{
    public class SiteChecker
    {
        public async Task<int> GetStatusCode(string siteurl)
        {
            var client = new HttpClient();
            var httpResponse = await client.GetAsync(siteurl);
            return (int)httpResponse.StatusCode;
        }

        public double AverageRating(IEnumerable<int> ratings)
        {
            return ratings.Average();
        }
    }
}
