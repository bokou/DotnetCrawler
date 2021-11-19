using System;
using System.Collections.Generic;

namespace DotnetCrawler.Sample.Models
{
    public partial class CatalogBrands
    {
        public CatalogBrands()
        {
            Catalog = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Catalog> Catalog { get; set; }
    }
}
