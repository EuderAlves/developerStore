import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor() {}

  saveCart(cart: any[]): void {
    localStorage.setItem('cart', JSON.stringify(cart));
  }

  getCart(): any[] {
    const storedCart = localStorage.getItem('cart');
    return storedCart ? JSON.parse(storedCart) : [];
  }

  clearCart(): void {
    localStorage.removeItem('cart');
  }
}
