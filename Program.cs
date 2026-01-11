namespace Async_Downloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Downloader downloader = new Downloader();
            Analyzer analyzer = new Analyzer();

            var pages = downloader.DownloadUrlsAsync();

            Console.ReadKey();
        }
    }
}
