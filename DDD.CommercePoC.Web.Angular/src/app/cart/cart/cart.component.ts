import { Component, OnInit } from '@angular/core';

import Cartservice = require('../cart-service/cart.service');
import CartService = Cartservice.CartService;
import Cart = require('../ICart');
import ICart = Cart.ICart;

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: ICart;
  cartContentCount: number;

  constructor(private readonly _cartService: CartService) { }

  ngOnInit() {
    this._cartService.getCart()
      .subscribe(data => {
        this.cart = data;
        this.cartContentCount = data.cartLineItems.map(cli => cli.count).reduce((a, b) => a + b, 0);
      });
  }

}
