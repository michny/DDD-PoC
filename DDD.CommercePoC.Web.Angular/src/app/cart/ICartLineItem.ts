export interface ICartLineItem
{
  id: string;
  count: number;
  variantId: string;
  variantName: string;
  price: number;
  currency: string;
  priceFormatted: string;
}
