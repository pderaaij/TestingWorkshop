<?php
namespace CheckoutPHP;
use CheckoutPHP\Commands\AddProductCommand;


class Cart {

    /** @var CartItem[] */
    private $_items = [];

    public function handleAddProductCommand(AddProductCommand $command = null) {
        if ($command == null) { throw new \InvalidArgumentException();}
    }
}