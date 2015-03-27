using System.Collections.Generic;
using System.Web;

namespace jQueryMobile.Models
{
    /// <summary>
    /// Session helper
    /// </summary>
    public class SessionHelper
    {
        #region Public Methods

        /// <summary>
        /// Get the shopping cart from the session
        /// </summary>
        /// <returns><see cref="ShoppingCart" /> object</returns>
        public static ShoppingCart GetCart()
        {
            var session = HttpContext.Current.Session;

            if (session["ShoppingCart"] != null)
                return (ShoppingCart) session["ShoppingCart"];

            var shoppingCart = new ShoppingCart
            {
                Items = new List<ShoppingCartItem>()
            };

            session["ShoppingCart"] = shoppingCart;

            return shoppingCart;
        }

        #endregion
    }
}