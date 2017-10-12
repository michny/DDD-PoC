import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { ICartLineItem } from '../ICartLineItem';
import { ICart } from '../ICart';

@Injectable()
export class CartService {

  private readonly _url: string = '/api/cart';

  @Output()
  cartLineItemUpdated = new EventEmitter<ICartLineItem>();

  constructor(private readonly _httpClient: HttpClient) { }

  addToCart(variantId: string): Observable<ICartLineItem> {
    console.log(`Adding variant with id ${variantId} to cart...`);
    return this._httpClient.post(this._url + '/' + variantId, {}, { })
      .do(data => {
        console.log(`Result from service: ${JSON.stringify(data)}`);
        this.cartLineItemUpdated.emit(data as ICartLineItem);
      })
      .catch(this.handleError);
  };

  getCart(): Observable<ICart> {
    console.log('Getting current cart');
    return this._httpClient.get(this._url)
      .do(data => console.log(`Received cart ${JSON.stringify(data)}`))
      .catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    //TODO Perhaps log to a logging service or something
    console.log(err.message);
    return Observable.throw(err.message); //throwing error to calling code
  };

}
