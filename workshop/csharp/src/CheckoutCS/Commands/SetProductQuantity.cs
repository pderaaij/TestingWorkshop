using System;

namespace CheckoutCS.Commands {
    public class SetProductQuantity {
        public Guid Id { get; }

        public int Quantity { get; }

        public SetProductQuantity(Guid id, int quantity) {
            Id = id;
            Quantity = quantity;
        }
    }
}