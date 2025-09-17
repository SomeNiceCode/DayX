namespace DayX.Database.Carts
{
    /// <summary>
    /// Представляет товар, добавленный в корзину пользователя.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Уникальный идентификатор элемента корзины.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор корзины, к которой относится товар.
        /// </summary>
        public Guid CartId { get; private set; }

        /// <summary>
        /// Идентификатор варианта продукта, добавленного в корзину.
        /// </summary>
        public Guid ProductVariantId { get; private set; }

        /// <summary>
        /// Количество единиц товара.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private CartItem() { }

        /// <summary>
        /// Создаёт новый элемент корзины.
        /// </summary>
        /// <param name="cartId">Идентификатор корзины.</param>
        /// <param name="productVariantId">Идентификатор варианта продукта.</param>
        /// <param name="quantity">Количество товара.</param>
        /// <returns>Новый экземпляр CartItem.</returns>
        public static CartItem Create(Guid cartId, Guid productVariantId, int quantity)
        {
            if (cartId == Guid.Empty)
                throw new ArgumentException("Cart ID cannot be empty.");

            if (productVariantId == Guid.Empty)
                throw new ArgumentException("ProductVariant ID cannot be empty.");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

            return new CartItem
            {
                Id = Guid.NewGuid(),
                CartId = cartId,
                ProductVariantId = productVariantId,
                Quantity = quantity
            };
        }
    }
}
