import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/core/services/item.service';
import { CartService } from 'src/app/core/services/cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-purchase-items',
  templateUrl: './purchase-items.component.html',
  styleUrls: ['./purchase-items.component.scss'],
})
export class PurchaseItemsComponent implements OnInit {
  items: any[] = [];
  cart: any[] = [];

  constructor(
    private itemService: ItemService,
    private cartService: CartService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.itemService.getAllItems().subscribe((items) => {
      this.items = items;
    });
  }

  addToCart(item: any, quantity: number): void {
    if (quantity > 20) {
      alert('A quantidade solicitada excede a quantidade maxima permitida.');
      return;
    }

    const existingItem = this.cart.find(
      (cartItem) => cartItem.productId === item.productId
    );

    if (existingItem) {
      existingItem.quantity += quantity;
    } else {
      this.cart.push({ ...item, quantity });
    }

    this.cartService.saveCart(this.cart);

    item.stockQuantity -= quantity;

    item.quantity = 0;
  }

  viewCart(): void {
    this.router.navigate(['/cart']);
  }

  validateQuantity(item: any): void {
    if (item.quantity > item.stockQuantity || item.quantity > 20) {
      item.quantity = item.stockQuantity > 20 ? 20 : item.stockQuantity;
    }
  }

  goBack(): void {
    this.router.navigate(['/home']);
  }
}
