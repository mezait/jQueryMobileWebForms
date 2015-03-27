using System.Collections.Generic;
using System.Linq;

namespace jQueryMobile.Models
{
    /// <summary>
    /// Sample data
    /// </summary>
    public class SampleData
    {
        private static readonly List<Product> Products = new List<Product>
            {
                new Product
                    {
                        Description = "Widget one description",
                        Name = "Widget one",
                        Price = 20,
                        Sku = "1"
                    },
                new Product
                    {
                        Description = "Widget two description",
                        Name = "Widget two",
                        Price = 10,
                        Sku = "2"
                    },
                new Product
                    {
                        Description = "Widget three description",
                        Name = "Widget three",
                        Price = 30,
                        Sku = "3"
                    }
            };

        #region Public Methods

        /// <summary>
        /// Retrieve a particular product
        /// </summary>
        /// <param name="sku">Sku of the product</param>
        /// <returns><see cref="Product" /> object</returns>
        public static Product GetProduct(string sku)
        {
            return Products.FirstOrDefault(p => p.Sku == sku);
        }

        /// <summary>
        /// Return a list of sample products
        /// </summary>
        /// <returns>List of <see cref="Product" /> objects</returns>
        public static IList<Product> GetProducts()
        {
            return Products;
        }

        #endregion
    }
}