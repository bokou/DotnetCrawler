using DotnetCrawler.Core;
using DotnetCrawler.Data.Models;
using DotnetCrawler.Downloader;
using DotnetCrawler.Pipeline;
using DotnetCrawler.Processor;
using DotnetCrawler.Request;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCrawler.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            string url = "https://www.ebay.com/b/Apple-Cell-Phones-Smartphones/9355/bn_319682";
            //url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313&_nkw=used+cars&_sacat=0";
            //url = "";

            var crawler = new DotnetCrawler<Catalog>()
                                 .AddRequest(new DotnetCrawlerRequest { Url = url, Regex = @".*itm/.+", TimeOut = 5000 })
                                 .AddDownloader(new DotnetCrawlerDownloader { DownloderType = DotnetCrawlerDownloaderType.FromFile, DownloadPath = @"C:\DotnetCrawler\" })
                                 .AddProcessor(new DotnetCrawlerProcessor<Catalog> { })
                                 .AddPipeline(new DotnetCrawlerPipeline<Catalog> { });

            await crawler.Crawle();
        }
    }
}
