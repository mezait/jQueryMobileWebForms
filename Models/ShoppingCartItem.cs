namespace jQueryMobile.Models
{
    /// <summary>
    /// Shopping cart item
    /// </summary>
    public class ShoppingCartItem
    {
        #region Public Properties

        public Product Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal
        {
            get { return Price*Quantity; }
        }

        #endregion

        #region Protected Methods

        protected bool Equals(ShoppingCartItem other)
        {
            return Equals(Product, other.Product);
        }

        #endregion

        #region Public Methods

        public override int GetHashCode()
        {
            return (Product != null ? Product.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            // We need to override equality operators for 'index of' to work
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals((ShoppingCartItem) obj);
        }

        #endregion
    }
}