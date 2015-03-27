using System;
using System.Web.UI;

namespace jQueryMobile
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            ctlShoppingCart.DataBind();
        }
    }
}