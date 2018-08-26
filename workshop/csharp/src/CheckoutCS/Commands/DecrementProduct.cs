using System;

namespace CheckoutCS.Commands {
    public class DecrementProduct {
        public Guid Id { get; }

        public DecrementProduct(Guid id) {
            Id = id;
        }
    }
}