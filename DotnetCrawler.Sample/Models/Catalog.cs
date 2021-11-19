using System;
using System.Collections.Generic;

namespace DotnetCrawler.Sample.Models
{
    public partial class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }

        public virtual CatalogBrands CatalogBrand { get; set; }
        public virtual CatalogTypes CatalogType { get; set; }
    }
}
