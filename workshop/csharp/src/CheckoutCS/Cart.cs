using System;
using System.Collections;
using System.Collections.Generic;
using CheckoutCS.Commands;
using System.Linq;

namespace CheckoutCS
{

    public class Cart
    {
        private List<CartItem> _CartItems = new List<CartItem>(); 
        public IEnumerable<CartItem> Items => _CartItems;

        public Cart(IEnumerable<CartItem> cartItems) {
            _CartItems = cartItems.ToList();
        }

        public void Handle(AddProduct cmd)
        {
            if (cmd == null) { throw new ArgumentNullException(); }
            if (cmd.Id == Guid.Empty) { throw new ArgumentException(); }

            CartItem item = new CartItem {
                Quantity = 1,
                Product = new Product(
                    cmd.Id,
                    cmd.Code,
                    cmd.Description,
                    cmd.Amount,
                    cmd.Version
                )
            };

            _CartItems.Add(item);
        }

        public void Handle(RemoveProduct cmd)
        {
            if (cmd == null) { throw new ArgumentNullException(); }
            if (cmd.Id == Guid.Empty) { throw new ArgumentException(); }

            _CartItems.RemoveAll(x => x.Product.Id == cmd.Id);
        }

        public void Handle(IncrementProduct cmd)
        {
           CartItem item = _CartItems.Find(x => x.Product.Id == cmd.Id);
           
           if (item != null) {
               item.Increment();
           } else {
               throw new InvalidOperationException($"Could not increment product with ID {cmd.Id} as it was not found in the cart.");
           }
        }

        public void Handle(DecrementProduct cmd)
        {
            CartItem item = _CartItems.Find(x => x.Product.Id == cmd.Id);

            if (item != null) {
                if (item.Quantity == 1) {
                    _CartItems.Remove(item);
                } else {
                    item.Decrement();
                }
            } else {
                throw new InvalidOperationException($"Could not decrement product with ID {cmd.Id} as it was not found in the cart.");
            }
        }

        public void Handle(SetProductQuantity cmd)
        {
            CartItem item = _CartItems.Find(x => x.Product.Id == cmd.Id);

            if (item != null) {
                item.Quantity = cmd.Quantity;
            } else {
                throw new InvalidOperationException($"Could not set quantity of product with ID {cmd.Id} as it was not found in the cart.");
            }
        }

        public decimal GetValue()
        {
            if (_CartItems.Count() == 0) {
                return 0.0m;
            }

            decimal value = 0.0m;

            _CartItems.ForEach(item => {
                value += item.Quantity * item.Product.Amount;
            });

            return value;
        }
    }
}
