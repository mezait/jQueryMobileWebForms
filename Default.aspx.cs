using System;
using System.Web.UI;
using jQueryMobile.Models;

namespace jQueryMobile
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            rptProducts.DataSource = SampleData.GetProducts();
            rptProducts.DataBind();
        }
    }
}