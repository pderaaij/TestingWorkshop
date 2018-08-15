using System;
using System.Linq;
using Xunit;

using CheckoutCS.Commands;
using CheckoutCS.Tests.Helpers;

namespace CheckoutCS.Tests.Unit
{
    public class CartTests
    {
        [Fact]
        public void AddProduct_WithNull_ThrowsArgumentNullException()
        {
            Cart cart = A.Cart;
            AddProduct cmd = null;

            Assert.Throws<ArgumentNullException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void AddProduct_WithEmptyProduct_ThrowsArgumentException() {
            Cart cart = A.Cart;
            AddProduct cmd = A.AddProduct.WithGuid(Guid.Empty);

            Assert.Throws<ArgumentException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void AddProduct_WithValidCommand_AddsCartItemToCart()
        {
            Cart cart = A.Cart;
            AddProduct cmd = A.AddProduct;

            cart.Handle(cmd);

            Assert.NotEmpty(cart.Items);
        }

        public void RemoveProduct_WithNull_ThrowsArgumentNullException() {
            Cart cart = A.Cart;
            RemoveProduct cmd = null;

            Assert.Throws<ArgumentNullException>(() => cart.Handle(cmd));
        }


        [Fact]
        public void RemoveProduct_WithEmptyProduct_ThrowsArgumentException() {
            Cart cart = A.Cart;
            RemoveProduct cmd = new RemoveProduct(Guid.Empty);

            Assert.Throws<ArgumentException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void RemoveProduct_WithValidProduct_RemovesProduct() {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id));
            RemoveProduct cmd = A.RemoveProduct.WithGuid(id);

            cart.Handle(cmd);
            
            Assert.Empty(cart.Items);
        }

        [Fact]
        public void IncrementProduct_WithValidCommand_IncrementsProduct() {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id));
            IncrementProduct cmd = A.IncrementProduct(id);

            cart.Handle(cmd);
            
            Assert.Equal(2, cart.Items.First().Quantity);
        }
    }
}
