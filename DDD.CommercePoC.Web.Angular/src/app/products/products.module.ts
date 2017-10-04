import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsService } from './productsservice/products.service';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductGuardService } from './product-guard/product-guard.service';
import { CartModule } from '../cart/cart.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ProductsRoutingModule,
    CartModule
  ],
  declarations: [
    ProductListComponent,
    ProductDetailsComponent
  ],
  exports: [
    ProductListComponent,
    ProductDetailsComponent
  ],
  providers: [ProductsService, ProductGuardService]
})
export class ProductsModule { }
