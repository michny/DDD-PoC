import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../productsservice/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  allProducts: IProduct[];
  filteredProducts: IProduct[];

  constructor(private readonly _productsService : ProductsService) { }

  ngOnInit() {
    this._productsService.getProducts()
      //Subscribing to the products data from the productservice and putting the data in the products array and updating the filteredProducts array
      .subscribe(products => {
        this.allProducts = products;
          this.filteredProducts = this.allProducts;
        },
        error => console.log(error)); //TODO This should be logged properly instead and shown to user. Should also generalize error handling for service calls
  }

}
