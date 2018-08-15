using System;
using System.Collections.Generic;

namespace CheckoutCS.Tests.Helpers
{
    internal class CartBuilder
    {
        private List<CartItem> _cartItems = new List<CartItem>();

        public Cart Build()
        {
            var cart =  new Cart(_cartItems);
            return cart;
        }

        public static implicit operator Cart(CartBuilder builder) => builder.Build();

        internal CartBuilder Containing(params CartItemBuilder[] cartItemBuilders)
        {
            foreach (CartItem builder in cartItemBuilders)
            {
                _cartItems.Add(builder);
            }
            return this;
        }
    }
}