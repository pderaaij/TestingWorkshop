<?php

namespace CheckoutPHP;

class Product {
    /** @var string */
    private $id;
    /** @var string */
    private $code;
    /** @var string */
    private $description;
    /** @var float */
    private $amount;
    /** @var int */
    private $version;

    public function __construct(string $id, string $code, string $description, float $amount, int $version) {
        $this->id = $id;
        $this->code = $code;
        $this->description = $description;
        $this->amount = $amount;
        $this->version = $version;
    }

    public function getId() : int {
        return $this->id;
    }
}