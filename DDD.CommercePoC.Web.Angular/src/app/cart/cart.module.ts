import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CartRoutingModule } from './cart-routing.module';
import { CartService } from './cart-service/cart.service';
import { CartComponent } from './cart/cart.component';
import { CartIconComponent } from './cart-icon/cart-icon.component';

@NgModule({
  imports: [
    CommonModule,
    CartRoutingModule
  ],
  declarations: [CartComponent, CartIconComponent],
  exports: [ CartIconComponent ],
  providers: [CartService]
})
export class CartModule { }
