<?php
namespace CheckoutPHP\Tests\Unit;
use CheckoutPHP\Tests\Helpers\A;

class CartTests extends \PHPUnit\Framework\TestCase {

    /**
     * @expectedException \InvalidArgumentException
     */
    public function testAddProductWithNull_Throws_InvalidArgumentException() {
        $cart = A::Cart();
        $cart->handleAddProductCommand(null);
    }
}