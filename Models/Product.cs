namespace jQueryMobile.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        #region Public Properties

        public string Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        #endregion

        #region Protected Methods

        protected bool Equals(Product other)
        {
            return string.Equals(Sku, other.Sku);
        }

        #endregion

        #region Public Methods

        public override int GetHashCode()
        {
            return (Sku != null ? Sku.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals((Product) obj);
        }

        #endregion
    }
}