using System;
using CheckoutCS.Commands;

namespace CheckoutCS.Tests.Helpers {
    internal static class A {
        internal static AddProductBuilder AddProduct => new AddProductBuilder();

        internal static CartBuilder Cart => new CartBuilder();

        internal static CartItemBuilder Item => new CartItemBuilder();

        internal static RemoveProductBuilder RemoveProduct => new RemoveProductBuilder();

        internal static IncrementProduct IncrementProduct(Guid id) => new IncrementProduct(id);
    }
}