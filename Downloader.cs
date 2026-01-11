using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Async_Downloader
{
    internal class Downloader
    {
        public async Task<List<string>> DownloadUrlsAsync()
        {
            using HttpClient client = new HttpClient();
            List<string> urls = new();

            foreach (string line in File.ReadAllLines("urls.txt"))
            {
                urls.Add(line);
            }

            var tasks = urls.Select(url => client.GetStringAsync(url));

            string[] pages = await Task.WhenAll(tasks);

            Console.WriteLine($"Downloaded {pages.Length} pages");

            return pages.ToList();
        }
    }
}
