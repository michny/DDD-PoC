import CartLineItem = require('./ICartLineItem');
import ICartLineItem = CartLineItem.ICartLineItem;

export interface ICart 
{
  id: string;
  customerId: string;
  cartLineItems: ICartLineItem[]; 
}