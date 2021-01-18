using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerce.Net.Domain;
using WooCommerce.Net.Utils;

namespace WooCommerce.Net.Service
{
    public class ProductService : Service
    {
        public ProductService(ApiDriver apiDriver) : base(apiDriver) {  }

        // View List of Products
        public IEnumerable<Product> Get(Dictionary<string, string> parameters = null)
        {
            return Get<IEnumerable<Product>>("products", parameters);
        }

        // View Product
        public Product GetId(int productId, Dictionary<string, string> parameters = null)
        {
            return Get<Product>(String.Format("products/{0}", productId), parameters);
        }

        // Create a Product
        public Product Create(Product productData, Dictionary<string, string> parameters = null)
        {
            return Post("products", parameters, productData);
        }

        // Update a Product
        public Product Put(int productId, Product newData, Dictionary<string, string> parameters = null)
        {
            return Put(String.Format("products/{0}", productId), parameters, newData);
        }
    }
}
