import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class ProductsService {
  private readonly _productUrl: string = 'api/products';

  constructor(private readonly _httpClient: HttpClient) { }

  getProducts(): Observable<IProduct[]> {
    return this._httpClient.get(this._productUrl)
      .do(data => console.log(`All: ${JSON.stringify(data)}`))
      .catch(this.handleError);
  };

  getProduct(id: string): Observable<IProduct> {
    return this._httpClient.get(`${this._productUrl}/${id}`)
      .do(data => console.log(`Single product: ${JSON.stringify(data)}`))
      .catch(this.handleError);
  };

  private handleError(err: HttpErrorResponse) {
    //TODO Perhaps log to a logging service or something
    console.log(err.message);
    return Observable.throw(err.message); //throwing error to calling code
  };
}
