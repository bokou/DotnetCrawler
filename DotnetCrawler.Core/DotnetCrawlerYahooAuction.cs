using DotnetCrawler.Data.Repository;
using DotnetCrawler.Downloader;
using DotnetCrawler.Pipeline;
using DotnetCrawler.Processor;
using DotnetCrawler.Request;
using DotnetCrawler.Scheduler;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DotnetCrawler.Core
{
    [Table("DotnetCrawler")]
    public class DotnetCrawlerYahooAuction<TEntity> : IDotnetCrawler where TEntity : class, IEntity
    {
        public IDotnetCrawlerRequest Request { get; private set; }
        public IDotnetCrawlerDownloader Downloader { get; private set; }
        public IDotnetCrawlerProcessor<TEntity> Processor { get; private set; }
        public IDotnetCrawlerScheduler Scheduler { get; private set; }
        public IDotnetCrawlerPipeline<TEntity> Pipeline { get; private set; }

        public DotnetCrawlerYahooAuction()
        {

        }

        public DotnetCrawlerYahooAuction<TEntity> AddRequest(IDotnetCrawlerRequest request)
        {
            Request = request;
            return this;
        }

        public DotnetCrawlerYahooAuction<TEntity> AddDownloader(IDotnetCrawlerDownloader downloader)
        {
            Downloader = downloader;
            return this;
        }

        public DotnetCrawlerYahooAuction<TEntity> AddProcessor(IDotnetCrawlerProcessor<TEntity> processor)
        {
            Processor = processor;
            return this;
        }

        public DotnetCrawlerYahooAuction<TEntity> AddScheduler(IDotnetCrawlerScheduler scheduler)
        {
            Scheduler = scheduler;
            return this;
        }

        public DotnetCrawlerYahooAuction<TEntity> AddPipeline(IDotnetCrawlerPipeline<TEntity> pipeline)
        {
            Pipeline = pipeline;
            return this;
        }

        public async Task Crawle()
        {
            var linkReader = new DotnetCrawlerPageLinkReader(Request);
            var links = await linkReader.GetLinks(Request.Url, 0);

            foreach (var url in links)
            {
                var document = await Downloader.Download(url); 
                var entity = await Processor.Process(document);
                await Pipeline.Run(entity);
            }
        }
    }
}
