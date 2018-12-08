<?php
namespace CheckoutPHP\Commands;

class AddProduct {
        /** @var int */
        private $id;

        /** @var string */
        private $code;
    
        /** @var string */
        private $description;
    
        /** @var float */
        private $amount;
    
        /** @var int */
        private $version;
    
        public function __construct(int $id, string $code, string $description, float $amount, int $version) {
            $this->id = $id;
            $this->code = $code;
            $this->description = $description;
            $this->amount = $amount;
            $this->version = $version;
        }
    
        /**
         * Get the value of id
         */
        public function getId()
        {
            return $this->id;
        }
    
        /**
         * Get the value of code
         */
        public function getCode()
        {
            return $this->code;
        }
    
        /**
         * Get the value of description
         */
        public function getDescription()
        {
            return $this->description;
        }
    
        /**
         * Get the value of amount
         */
        public function getAmount()
        {
            return $this->amount;
        }
    
        /**
         * Get the value of version
         */
        public function getVersion()
        {
            return $this->version;
        }
}