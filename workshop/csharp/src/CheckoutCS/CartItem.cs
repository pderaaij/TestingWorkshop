namespace CheckoutCS {
    public class CartItem {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public void Increment() {
            Quantity++;
        }
    }
}