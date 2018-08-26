using System;

namespace CheckoutCS.Tests.Helpers {
    internal class CartItemBuilder {

        private Guid id = Guid.Parse("fffd6fb6-590b-4455-8768-53452676253c");
        private string code = "ITEM1234";
        private string name = "Test product";
        private string description = "Lorem ipsum description of a Product";
        private decimal amount = 1.0m;
        private long version = 0;
        private int Quantity = 1;

        public CartItem Build()
        {
            var cartItem =  new CartItem();
            cartItem.Quantity = Quantity;
            cartItem.Product = new Product(id, code, description, amount, version);

            return cartItem;
        }

        public static implicit operator CartItem(CartItemBuilder builder) => builder.Build();

        internal CartItemBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        internal CartItemBuilder WithQuantity(int qty)
        {
            this.Quantity = qty;
            return this;
        }
    }
}