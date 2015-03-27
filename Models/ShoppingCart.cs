using System.Collections.Generic;
using System.Linq;

namespace jQueryMobile.Models
{
    /// <summary>
    /// Shopping cart
    /// </summary>
    public class ShoppingCart
    {
        #region Public Properties

        public IList<ShoppingCartItem> Items { get; set; }

        public int ItemCount
        {
            get { return Items.Sum(item => item.Quantity); }
        }

        public string SubTotal
        {
            get { return Items.Sum(item => item.SubTotal).ToString("c"); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add an item to the shopping cart
        /// </summary>
        /// <param name="cartItem"><see cref="ShoppingCartItem" /> object</param>
        public void AddCartItem(ShoppingCartItem cartItem)
        {
            var i = Items.IndexOf(cartItem);

            if (i >= 0)
            {
                // If the cart item exists
                if (cartItem.Quantity > 0)
                    // ... and the quantity is greater than zero, adjust the quantity
                    Items[i].Quantity += cartItem.Quantity;
                else
                    // ... otherwise remove the item
                    Items.RemoveAt(i);
            }
            else
            {
                // The item does not exist, add it
                if (cartItem.Quantity > 0)
                    Items.Add(cartItem);
            }
        }

        /// <summary>
        /// Empty the shopping cart
        /// </summary>
        public void EmptyCart()
        {
            Items.Clear();
        }

        /// <summary>
        /// Remove an item from the shopping cart
        /// </summary>
        /// <param name="cartItem"><see cref="ShoppingCartItem" /> object</param>
        public void RemoveCartItem(ShoppingCartItem cartItem)
        {
            var i = Items.IndexOf(cartItem);

            if (i >= 0)
                Items.RemoveAt(i);
        }

        /// <summary>
        /// Update an item in the shopping cart
        /// </summary>
        /// <param name="cartItem"><see cref="ShoppingCartItem" /> object</param>
        public void UpdateCartItem(ShoppingCartItem cartItem)
        {
            var i = Items.IndexOf(cartItem);

            if (i < 0)
                return;

            // If the cart item exists
            if (cartItem.Quantity > 0)
                // ... and the quantity is greater than zero, adjust the quantity
                Items[i].Quantity = cartItem.Quantity;
            else
                // ... otherwise remove the item
                Items.RemoveAt(i);
        }

        #endregion
    }
}