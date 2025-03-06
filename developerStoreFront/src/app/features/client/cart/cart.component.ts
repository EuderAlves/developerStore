import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SaleService } from 'src/app/core/services/sale.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {
  cart: any[] = [];
  isPurchasesave: boolean = true;
  isPurchaseFinalized: boolean = true;
  isCancelPurchaseBlocked: boolean = true;
  purchaseSave: any;

  constructor(
    private router: Router,
    private snackBar: MatSnackBar,
    private saleService: SaleService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    const storedCart = localStorage.getItem('cart');
    this.cart = storedCart ? JSON.parse(storedCart) : [];
  }

  savePurchase(): void {
    var user: any;
    var userStore = this.userService.getUser();
    userStore.subscribe((data) => (user = data));
    const transformedArrayItem = this.cart.map((item) => ({
      productId: item.productId,
      quantity: item.quantity,
      unitPrice: item.unitPrice,
      discount: 0,
    }));
    const saveNewPurchase = {
      customerEmail: user.email,
      branch: user.companyName,
      items: transformedArrayItem,
    };
    this.saleService.savePurchase(saveNewPurchase).subscribe((response) => {
      this.isPurchasesave = false;
      this.isPurchaseFinalized = true;
      this.isCancelPurchaseBlocked = true;
      this.purchaseSave = response.body;
      this.openSnackBar('Compra salva com sucesso!');
    });
  }

  finalizePurchase(): void {
    this.saleService
      .finalizePurchase(this.purchaseSave.id)
      .subscribe((response) => {
        this.isCancelPurchaseBlocked = false;
        this.openSnackBar('Compra finalizada com sucesso!');
        localStorage.removeItem('cart');

        setTimeout(() => this.router.navigate(['/purchase-items']), 2000);
      });
  }

  cancelPurchase(): void {
    if (!this.purchaseSave) {
      this.isPurchaseFinalized = true;
      this.openSnackBar('É necessario salvar a compra antes de cancelar!');
      return;
    }
    this.saleService
      .cancelPurchase(this.purchaseSave.id)
      .subscribe((response) => {
        this.openSnackBar('Compra cancelada!');
        setTimeout(() => this.router.navigate(['/purchase-items']), 2000);
      });
  }

  getTotalValue(): number {
    return this.cart.reduce((total, item) => {
      const itemTotal = item.unitPrice * item.quantity;
      return total + itemTotal * this.getDiscount(item);
    }, 0);
  }

  getDiscount(item: any): number {
    if (item.quantity < 4) {
      return 1;
    } else if (item.quantity >= 10 && item.quantity <= 20) {
      return 0.8;
    } else if (item.quantity > 4) {
      return 0.9;
    }
    return 1;
  }

  updateItemQuantity(item: any): void {
    if (item.quantity > 20) {
      item.quantity = 20;
      alert('Não é possível vender mais de 20 itens idênticos.');
    }
    this.saveCart();
  }

  removeItem(item: any): void {
    this.cart = this.cart.filter(
      (cartItem) => cartItem.productId !== item.productId
    );
    this.saveCart();
  }

  saveCart(): void {
    localStorage.setItem('cart', JSON.stringify(this.cart));
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }

  goBack(): void {
    this.router.navigate(['/purchase-items']);
  }
}
