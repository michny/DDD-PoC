import { Component, OnInit } from '@angular/core';
import Cartservice = require('../cart-service/cart.service');
import CartService = Cartservice.CartService;

@Component({
  selector: 'app-cart-icon',
  templateUrl: './cart-icon.component.html',
  styleUrls: ['./cart-icon.component.css']
})
export class CartIconComponent implements OnInit {

  contentCount: number;
  contentPrice: string;

  constructor(private readonly _cartService: CartService) { }

  ngOnInit() {
    this.updateContentCount();

    //Subscribing to the cartLineItemUpdated event and then retrieving the cart again to get number of items in it
    this._cartService.cartLineItemUpdated.subscribe(value => {
      console.log(`Received ${JSON.stringify(value)} from cartService event.`);
      this.updateContentCount();
    });
  }

  private updateContentCount(): void {
    this._cartService.getCart().subscribe(cart => {
      //Equivalent to "cart.CartLineItems.Select(l => l.count).Sum(c => c); in C#"
      this.contentCount = cart.cartLineItems.map(l => l.count).reduce((a, b) => a + b, 0);
      this.contentPrice = cart.priceFormatted;
    });
  }
}
