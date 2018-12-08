<?php
namespace CheckoutPHP;

use CheckoutPHP\Commands\AddProduct;
use CheckoutPHP\Commands\RemoveProduct;

class Cart {

    /** @var CartItem[] */
    private $_items = [];

    public function __construct($items) {
        $this->_items = $items;
    }

    public function handleAddProductCommand(AddProduct $command = null) {
        if ($command == null) { throw new \InvalidArgumentException();}
        if ($command->getId() === 0) { throw new \InvalidArgumentException();}

        $this->_items[] = new CartItem(
            new Product(
                $command->getId(),
                $command->getCode(),
                $command->getDescription(),
                $command->getAmount(),
                $command->getVersion()
            ),
            1
        );
    }

    public function handleRemoveProductCommand(RemoveProduct $command) {
        /** @var CartItem $item */
        foreach ($this->_items as $key => $item) {
            if ($item->getProductId() === $command->getId()) {
                unset($this->_items[$key]);
                return;
            }
        } 
    }

    public function getNumberOfItems() : int {
        return count($this->_items);
    }
}