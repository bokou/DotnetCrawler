using DotnetCrawler.Data.Attributes;
using DotnetCrawler.Data.Repository;
using System;
using System.Collections.Generic;

namespace DotnetCrawler.Data.Models
{
    [DotnetCrawlerEntity(XPath = "//*[@class='l-contents']")]
    public partial class Catalog : IEntity
    {
        public int Id { get; set; }
        [DotnetCrawlerField(Expression = "1", SelectorType = SelectorType.FixedValue)]
        public int CatalogBrandId { get; set; }
        [DotnetCrawlerField(Expression = "1", SelectorType = SelectorType.FixedValue)]
        public int CatalogTypeId { get; set; }

        //[DotnetCrawlerField(Expression = "//*div[contains(@class,'ProductExplanation__commentBody']/text()", SelectorType = SelectorType.XPath)]
        [DotnetCrawlerField(Expression = "div.ProductExplanation__commentBody", SelectorType = SelectorType.CssSelector)]
        public string Description { get; set; }

        [DotnetCrawlerField(Expression = "//*[@class='ProductTitle__text']/text()", SelectorType = SelectorType.XPath)]
        public string Name { get; set; }

        [DotnetCrawlerField(Expression = "//*[@class='ProductImage__inner']/img[1]/@src", SelectorType = SelectorType.XPathAttribute)]
        public string PictureUri { get; set; }

        [DotnetCrawlerField(Expression = "//*[@class='Price__value']/text()", SelectorType =SelectorType.XPath)]
        public decimal Price { get; set; }

        public virtual CatalogBrand CatalogBrand { get; set; }
        public virtual CatalogType CatalogType { get; set; }
    }
}
