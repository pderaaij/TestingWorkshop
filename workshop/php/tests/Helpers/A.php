<?php
namespace CheckoutPHP\Tests\Helpers;

class A {

    public static function Cart() : CartBuilder {
        return new CartBuilder();
    }

    public static function AddProduct() : AddProductBuilder {
        return new AddProductBuilder();
    }

    public static function Item() : CartItemBuilder {
        return new CartItemBuilder();
    }

    public static function RemoveProduct() : RemoveProductBuilder {
        return new RemoveProductBuilder();
    }
}