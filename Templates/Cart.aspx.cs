using System;
using System.Linq;
using System.Web.UI;
using jQueryMobile.Models;

namespace jQueryMobile.Templates
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cart = SessionHelper.GetCart();

            if (!String.IsNullOrEmpty(Request.Params["op"]))
            {
                switch (Request.Params["op"])
                {
                    case "remove":
                        if (!String.IsNullOrEmpty(Request.Params["sku"]))
                        {
                            var cartItem = cart.Items.FirstOrDefault(c => c.Product.Sku == Request.Params["sku"]);

                            if (cartItem != null)
                                cart.RemoveCartItem(cartItem);
                        }

                        break;

                    case "removeall":
                        cart.EmptyCart();

                        break;
                }
            }
            else if (Request.Form["sku"] != null && Request.Form["quantity"] != null)
            {
                var skus = Request.Form["sku"].Split(',');
                var quantities = Request.Form["quantity"].Split(',');

                for (var i = 0; i < skus.Length; i++)
                {
                    var cartItem = cart.Items.FirstOrDefault(c => c.Product.Sku == skus[i]);

                    if (cartItem == null)
                        continue;

                    cartItem.Quantity = Int32.Parse(quantities[i]);

                    cart.UpdateCartItem(cartItem);
                }
            }

            ctlShoppingCart.DataBind();
        }
    }
}