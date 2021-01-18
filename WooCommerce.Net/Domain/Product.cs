using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerce.Net.Domain
{
    public class Product
    {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime? date_created { get; set; }
            public DateTime? date_modified { get; set; }
            public decimal? price { get; set; }
            public decimal? regular_price { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public int? stock_quantity { get; set; }
            public bool? manage_stock { get; set; }
            public bool? in_stock { get; set; }

    }
}
