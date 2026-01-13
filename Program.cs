
namespace Async_Downloader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Downloader downloader = new Downloader();
            Analyzer analyzer = new Analyzer();

            List<string> pages = await downloader.DownloadUrlsAsync();
            analyzer.AnalyzePages(pages);

            Console.ReadKey();
        }
    }
}
