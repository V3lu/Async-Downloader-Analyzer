using File = System.IO.File;

namespace Async_Downloader
{
    internal class Downloader
    {
        public async Task<List<string>> DownloadUrlsAsync()
        {
            using HttpClient client = new HttpClient();
            List<string> urls = new();

            foreach (string line in await File.ReadAllLinesAsync("urls.txt"))
            {
                // Await here releases the thread and makes the OS read the file while the thread can do other stuff like add to urls read lines
                urls.Add(line);
            }

            // Each url is a task executed in async mode
            var tasks = urls.Select(url => client.GetStringAsync(url));

            //Here we wait for all the tasks to finish executing. These are executed on other thread since await released the current one
            string[] pages = await Task.WhenAll(tasks);

            Console.WriteLine($"Downloaded {pages.Length} pages");

            List<Task> tasksList = new();
            for(int i = 0; i < pages.Length; i++)
            {
                tasksList.Add(File.WriteAllTextAsync($"Page{i + 1}", pages[i]));
            }

            await Task.WhenAll(tasksList);

            //Modern C# list collection creating technique
            return [.. pages];
        }
    }
}
