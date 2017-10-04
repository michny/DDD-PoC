import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { ICartLineItem } from "../ICartLineItem";

@Injectable()
export class CartService {

  private readonly _url: string = '/api/cart';

  constructor(private readonly _httpClient: HttpClient) { }

  addToCartById(variantId: string): Observable<ICartLineItem> {
    console.log(`Adding variant with id ${variantId} to cart...`);
    return this._httpClient.post(this._url + '/' + variantId, {}, { })
      .do(data => console.log(`Result from service: ${JSON.stringify(data)}`))
      .catch(this.handleError);
  };

  addToCart(variant: IVariant): Observable<ICartLineItem> {
    console.log(`Adding variant ${JSON.stringify(variant)} to cart...`);
    return this.addToCartById(variant.id);
  };

  private handleError(err: HttpErrorResponse) {
    //TODO Perhaps log to a logging service or something
    console.log(err.message);
    return Observable.throw(err.message); //throwing error to calling code
  };

}
