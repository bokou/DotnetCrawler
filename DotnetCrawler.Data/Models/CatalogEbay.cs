using DotnetCrawler.Data.Attributes;
using DotnetCrawler.Data.Repository;
using System;
using System.Collections.Generic;

namespace DotnetCrawler.Data.Models
{
    [DotnetCrawlerEntity(XPath = "//*[@id='LeftSummaryPanel']/div[1]")]
    public partial class CatalogEbay : IEntity
    {
        public int Id { get; set; }
        [DotnetCrawlerField(Expression = "1", SelectorType = SelectorType.FixedValue)]
        public int CatalogBrandId { get; set; }
        [DotnetCrawlerField(Expression = "1", SelectorType = SelectorType.FixedValue)]
        public int CatalogTypeId { get; set; }        

        [DotnetCrawlerField(Expression = "//*[@id='vi-cond-addl-info']/text()", SelectorType=SelectorType.XPath)]
        public string Description { get; set; }
        [DotnetCrawlerField(Expression = "//*[@id='itemTitle']/text()", SelectorType = SelectorType.XPath)]
        public string Name { get; set; }

        [DotnetCrawlerField(Expression = "//*[@id='icImg']/@src", SelectorType = SelectorType.XPathAttribute)]
        public string PictureUri { get; set; }

        [DotnetCrawlerField(Expression = "//*[@id='prcIsum']/@content", SelectorType =SelectorType.XPathAttribute)]
        public decimal Price { get; set; }

        public virtual CatalogBrand CatalogBrand { get; set; }
        public virtual CatalogType CatalogType { get; set; }
    }
}
