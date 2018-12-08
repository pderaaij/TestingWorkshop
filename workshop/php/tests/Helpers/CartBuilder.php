<?php
namespace CheckoutPHP\Tests\Helpers;

use CheckoutPHP\Cart;
use CheckoutPHP\CartItem;

class CartBuilder {
    /**
     * @var CartItem[]
     */
    private $_items = [];

    public function build() : Cart {
        return new Cart($this->_items);
    }

    public function __invoke() {
        return $this->build();
    }

    public function Containing(CartItemBuilder $cartItemBuilder) {
        $this->_items[] = $cartItemBuilder();
        return $this;
    }
}