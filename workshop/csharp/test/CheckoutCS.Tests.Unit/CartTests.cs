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
        public void AddProduct_WithEmptyProduct_ThrowsArgumentException()
        {
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

        [Fact]
        public void RemoveProduct_WithNull_ThrowsArgumentNullException()
        {
            Cart cart = A.Cart;
            RemoveProduct cmd = null;

            Assert.Throws<ArgumentNullException>(() => cart.Handle(cmd));
        }


        [Fact]
        public void RemoveProduct_WithEmptyProduct_ThrowsArgumentException()
        {
            Cart cart = A.Cart;
            RemoveProduct cmd = new RemoveProduct(Guid.Empty);

            Assert.Throws<ArgumentException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void RemoveProduct_WithValidProduct_RemovesProduct()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id));
            RemoveProduct cmd = A.RemoveProduct.WithGuid(id);

            cart.Handle(cmd);

            Assert.Empty(cart.Items);
        }

        [Fact]
        public void IncrementProduct_WithValidCommand_IncrementsProduct()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id));
            IncrementProduct cmd = A.IncrementProduct(id);

            cart.Handle(cmd);

            Assert.Equal(2, cart.Items.First().Quantity);
        }

        [Fact]
        public void IncrementProduct_WithUnkownProduct_ThrowsInvalidOperationException()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart;
            IncrementProduct cmd = A.IncrementProduct(id);

            Assert.Throws<InvalidOperationException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void DecrementProduct_WithUnknownProduct_ThrowsInvalidOperationException()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart;
            DecrementProduct cmd = A.DecrementProduct(id);


            Assert.Throws<InvalidOperationException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void DecrementProduct_WithValidCommand_DecrementsProduct()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id).WithQuantity(2));
            DecrementProduct cmd = A.DecrementProduct(id);

            cart.Handle(cmd);

            Assert.Equal(1, cart.Items.First().Quantity);
        }

        [Fact]
        public void DecrementProduct_WithQuantityOfOne_RemovesProduct()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id).WithQuantity(1));
            DecrementProduct cmd = A.DecrementProduct(id);

            cart.Handle(cmd);

            Assert.Empty(cart.Items);
        }

        [Fact]
        public void SetProductQuantity_ForUnknownProduct_ThrowsInvalidOperationException()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart;
            SetProductQuantity cmd = A.SetProductQuantity(id, 2);

            Assert.Throws<InvalidOperationException>(() => cart.Handle(cmd));
        }

        [Fact]
        public void SetProductQuantity_WithValidProduct_SetsProductQuantity()
        {
            var id = Guid.NewGuid();
            Cart cart = A.Cart.Containing(A.Item.WithId(id));
            SetProductQuantity cmd = A.SetProductQuantity(id, 5);

            cart.Handle(cmd);

            Assert.Equal(5, cart.Items.First().Quantity);
        }

        [Fact]
        public void GetCartValue_WithEmptyCart_ReturnsZero()
        {
            Cart cart = A.Cart;

            Assert.Equal(0.0m, cart.GetValue());
        }

        [Fact]
        public void GetCartValue_WithProducts_SumsCorrectly()
        {
            Cart cart = A.Cart.Containing(A.Item.WithQuantity(2)).Containing(A.Item);

            Assert.Equal(2, cart.Items.Count());
            Assert.Equal(3.0m, cart.GetValue());
        }
    }
}
