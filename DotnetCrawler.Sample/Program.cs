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
            String runType = "yahoo_auction";
            //String runType = "ebay";

            if (runType.Equals("ebay"))
            {
                string url = "https://www.ebay.com/b/Apple-Cell-Phones-Smartphones/9355/bn_319682";
                //url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313&_nkw=used+cars&_sacat=0";

                var crawler = new DotnetCrawler<CatalogEbay>()
                                     .AddRequest(new DotnetCrawlerRequest { Url = url, Regex = @".*itm/.+", TimeOut = 5000 })
                                     .AddDownloader(new DotnetCrawlerDownloader { DownloderType = DotnetCrawlerDownloaderType.FromFile, DownloadPath = @"C:\DotnetCrawler\" })
                                     .AddProcessor(new DotnetCrawlerProcessor<CatalogEbay> { })
                                     .AddPipeline(new DotnetCrawlerPipeline<CatalogEbay> { });
                await crawler.Crawle();

            }else if (runType.Equals("yahoo_auction"))
            {
                string url = url = "https://auctions.yahoo.co.jp/category/list/2084005259/?brand_id=115839";
                var crawler = new DotnetCrawler<Catalog>()
                                     .AddRequest(new DotnetCrawlerRequest { Url = url, Regex = @".*auction/.+", TimeOut = 5000 })
                                     .AddDownloader(new DotnetCrawlerDownloader { DownloderType = DotnetCrawlerDownloaderType.FromFile, DownloadPath = @"C:\DotnetCrawler\yahooauction\" })
                                     .AddProcessor(new DotnetCrawlerProcessor<Catalog> { })
                                     .AddPipeline(new DotnetCrawlerPipeline<Catalog> { });
                await crawler.Crawle();
            }


        }
    }
}
