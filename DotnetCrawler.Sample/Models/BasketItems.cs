using System;
using System.Collections.Generic;

namespace DotnetCrawler.Sample.Models
{
    public partial class BasketItems
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CatalogItemId { get; set; }
        public int BasketId { get; set; }

        public virtual Baskets Basket { get; set; }
    }
}
