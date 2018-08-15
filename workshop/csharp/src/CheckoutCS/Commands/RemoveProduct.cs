using System;

namespace CheckoutCS.Commands {
    public class RemoveProduct {
        public Guid Id { get; }

        public RemoveProduct(Guid id) {
            Id = id;
        }
    }
}