using System;
using CheckoutCS.Commands;

namespace CheckoutCS.Tests.Helpers
{
    internal class AddProductBuilder
    {

        private Guid id = Guid.Parse("fffd6fb6-590b-4455-8768-53452676253c");
        private string code = "ITEM1234";
        private string name = "Test product";
        private string description = "Lorem ipsum description of a Product";
        private decimal amount = 1.0m;
        private long version = 0;

        public AddProduct Build()
        {
            var addProduct =  new AddProduct(id, code, name, description, amount, version);
            return addProduct;
        }

        public static implicit operator AddProduct(AddProductBuilder builder) => builder.Build();

        internal AddProductBuilder WithGuid(Guid id) {
            this.id = id;
            return this;
        }
    }
}