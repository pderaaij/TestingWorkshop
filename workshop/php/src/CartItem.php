<?php

namespace CheckoutPHP;

class CartItem {
    /** @var Product */
    private $product = null;

    /** @var int */
    private $quantity = 0;

    public function __construct(Product $product, int $quantity) {
        $this->product = $product;
        $this->quantity = $quantity;
    }

    public function getProductId() : int {
        if ($this->product !== null) {
            return $this->product->getId();;
        }

        throw new \RunTimeException("Unexpected empty product in CartItem");
    }
}