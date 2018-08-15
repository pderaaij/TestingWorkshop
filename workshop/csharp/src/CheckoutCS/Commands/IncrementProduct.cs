using System;

namespace CheckoutCS.Commands {
    public class IncrementProduct {
        public Guid Id { get; }

        public IncrementProduct(Guid id) {
            Id = id;
        }
    }
}