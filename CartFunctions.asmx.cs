using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using jQueryMobile.Models;

namespace jQueryMobile
{
    /// <summary>
    /// Cart functions
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class CartFunctions : WebService
    {
        /// <summary>
        /// Add an item to the shopping cart
        /// </summary>
        /// <param name="sku">Sku of the product</param>
        /// <returns>Shopping cart as JSON</returns>
        [WebMethod(EnableSession = true)]
        public string AddToCart(string sku)
        {
            var product = SampleData.GetProduct(sku);
            var shoppingCart = SessionHelper.GetCart();

            shoppingCart.AddCartItem(new ShoppingCartItem
                {
                    Price = product.Price,
                    Product = product,
                    Quantity = 1
                });

            return new JavaScriptSerializer().Serialize(shoppingCart);
        }

        /// <summary>
        /// Get the shopping cart
        /// </summary>
        /// <returns>Shopping cart as JSON</returns>
        [WebMethod(EnableSession = true)]
        public string GetCart()
        {
            return new JavaScriptSerializer().Serialize(SessionHelper.GetCart());
        }
    }
}