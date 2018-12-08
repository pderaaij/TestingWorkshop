<?php
namespace CheckoutPHP\Tests\Helpers;

use CheckoutPHP\Commands\AddProduct;

class AddProductBuilder
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

    public function build() : AddProduct {
        return new AddProduct(
            $this->id,
            $this->code,
            $this->description,
            $this->amount,
            $this->version
        );
    }

    public function __invoke() {
        return $this->build();
    }

    public function withId(int $id) {
        $this->id = $id;
        return $this;
    }

}
