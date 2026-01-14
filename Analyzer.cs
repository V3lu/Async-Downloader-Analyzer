using System;
using System.Collections.Generic;
using System.Text;

namespace Async_Downloader
{
    internal class Analyzer
    {
        public void AnalyzePages(List<string> pages)
        {
            int divcounter = pages.Count(eb => eb == "div");
            Console.WriteLine($"Divs used in the page: {divcounter / 2}");

        }
    }
}
