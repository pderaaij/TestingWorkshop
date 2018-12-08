<?php
namespace CheckoutPHP\Tests\Helpers;

use CheckoutPHP\Commands\RemoveProduct;

class RemoveProductBuilder {
    private $id = 1234;

    public function build() : RemoveProduct {
        return new RemoveProduct($this->id);
    }

    public function __invoke() {
        return $this->build();
    }

    public function withId($id) {
        $this->id = $id;
        return $this;
    }
}