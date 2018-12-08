<?php
namespace CheckoutPHP\Commands;

class RemoveProduct {
    /** @var int */
    private $_id;

    public function __construct(int $id) {
        $this->_id = $id;
    }

    public function getId() : int {
        return $this->_id;
    }
}