<?php
namespace CheckoutPHP\Tests\Unit;
use CheckoutPHP\Tests\Helpers\A;

class CartTests extends \PHPUnit\Framework\TestCase {

    /**
     * @expectedException \InvalidArgumentException
     */
    public function testAddProductWithNull_Throws_InvalidArgumentException() {
        $cart = A::Cart()();
        $cart->handleAddProductCommand(null);
    }

    /**
     * @expectedException \InvalidArgumentException
     */
    public function testAddProductWithEmptyProduct_Throws_InvalidArgumentException() {
        $cart = A::Cart()();
        $command = A::AddProduct()->withId(0);
       
        $cart->handleAddProductCommand($command());
    }

    public function testAddProduct_WithValidCommand_AddsItemToCart() {
        $cart = A::Cart()();
        $command = A::AddProduct();
       
        $cart->handleAddProductCommand($command());

        $this->assertEquals(1, $cart->getNumberOfItems());
    }

    public function testRemovingProduct_WithValidProduct_RemovesProduct() {
        $id = 1000;
        $cart = A::Cart()->Containing(A::Item()->withId($id))();
        $command = A::RemoveProduct()->withId($id);

        $cart->handleRemoveProductCommand($command());
        $this->assertEquals(0, $cart->getNumberOfItems());
    }
}