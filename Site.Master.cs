using System;
using System.Web.UI;
using jQueryMobile.Models;

namespace jQueryMobile
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            var shoppingCart = SessionHelper.GetCart();

            lblCartSummary.Text = String.Format("{0} Items, Total: {1}",
                shoppingCart.ItemCount,
                shoppingCart.SubTotal);
        }
    }
}