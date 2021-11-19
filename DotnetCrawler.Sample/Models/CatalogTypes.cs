using System;
using System.Collections.Generic;

namespace DotnetCrawler.Sample.Models
{
    public partial class CatalogTypes
    {
        public CatalogTypes()
        {
            Catalog = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Catalog> Catalog { get; set; }
    }
}
