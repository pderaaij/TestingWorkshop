using System;
using CheckoutCS.Commands;

namespace CheckoutCS.Tests.Helpers
{
    internal class RemoveProductBuilder
    {
        private Guid id = Guid.Parse("fffd6fb6-590b-4455-8768-53452676253c");

        public RemoveProduct Build()
        {
            var removeProduct = new RemoveProduct(id);
            return removeProduct;
        }

        public static implicit operator RemoveProduct(RemoveProductBuilder builder) => builder.Build();

        internal RemoveProductBuilder WithGuid(Guid id) {
            this.id = id;
            return this;
        }
    }
}