import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import Productsservice = require('../productsservice/products.service');
import ProductsService = Productsservice.ProductsService;
import Cartservice = require('../../cart/cart-service/cart.service');
import CartService = Cartservice.CartService;

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  
  product: IProduct;
  selectedVariant: IVariant;
  errorMessage: string;

  constructor(private readonly _route: ActivatedRoute,
              private readonly _router: Router,
              private readonly _productsService: ProductsService,
              private readonly _cartService: CartService) { }

  ngOnInit() {
    const id = this._route.snapshot.paramMap.get('id');
    this._productsService.getProduct(id)
      .subscribe(
        product => {
          this.product = product;
          this.selectedVariant = product.variants[0];
        },
        error => this.errorMessage = error);
  }

  addToCart(): void {
    this._cartService.addToCart(this.selectedVariant)
      .subscribe(data => {
        console.log(`Received cart lineitem ${JSON.stringify(data)} from cartService in product-details.`);
      });
  }
}
