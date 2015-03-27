using System.Web.UI;
using jQueryMobile.Models;

namespace jQueryMobile.Controls
{
    public partial class ShoppingCart : UserControl
    {
        public override void DataBind()
        {
            var cart = SessionHelper.GetCart();

            rptCartItems.DataSource = cart.Items;
            rptCartItems.DataBind();
        }
    }
}