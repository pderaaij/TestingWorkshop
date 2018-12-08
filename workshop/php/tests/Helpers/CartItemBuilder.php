<?php
namespace CheckoutPHP\Tests\Helpers;

use CheckoutPHP\CartItem;
use CheckoutPHP\Product;

class CartItemBuilder
{

    /** @var int */
    private $id = 131234208;

    /** @var string */
    private $code = "ITEM1234";

    /** @var string */
    private $description = "Test Product";

    /** @var float */
    private $amount = 10.25;

    /** @var int */
    private $version = 1;

    /** @var int */
    private $quantity = 1;

    public function build(): CartItem
    {
        return new CartItem(
            new Product($this->id, $this->code, $this->description, $this->amount, $this->version),
            $this->quantity
        );
    }

    public function __invoke()
    {
        return $this->build();
    }

    public function withId($id) {
        $this->id = $id;
        return $this;
    }
}
