using System;
using System.Collections.Generic;

namespace DotnetCrawler.Sample.Models
{
    public partial class Baskets
    {
        public Baskets()
        {
            BasketItems = new HashSet<BasketItems>();
        }

        public int Id { get; set; }
        public string BuyerId { get; set; }

        public virtual ICollection<BasketItems> BasketItems { get; set; }
    }
}
