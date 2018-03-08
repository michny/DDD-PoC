import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminIndexComponent } from './admin-index/admin-index.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';

const routes: Routes = [
  { path: 'admin/index', component: AdminIndexComponent },
  { path: 'admin/products', component: AdminProductsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
