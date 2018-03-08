import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminIndexComponent } from '../admin/admin-index/admin-index.component';
import { AdminProductsComponent } from '../admin/admin-products/admin-products.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AdminRoutingModule
  ],
  declarations: [AdminIndexComponent, AdminProductsComponent]
})
export class AdminModule { }
