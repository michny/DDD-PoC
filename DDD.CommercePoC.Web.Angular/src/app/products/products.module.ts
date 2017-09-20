import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsService } from './productsservice/products.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    ProductListComponent,
    ProductDetailsComponent
  ],
  exports: [
    ProductListComponent,
    ProductDetailsComponent
  ],
  providers: [ProductsService]
})
export class ProductsModule { }
