import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SaleService } from 'src/app/core/services/sale.service'; // Importe o SaleService
import { AuthService } from 'src/app/core/services/auth.service'; // Importe o AuthService
import { UserService } from 'src/app/core/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-sales-history',
  templateUrl: './sales-history.component.html',
  styleUrls: ['./sales-history.component.scss'],
})
export class SalesHistoryComponent implements OnInit {
  sales: any[] = [];
  userEmail: any;

  constructor(
    private saleService: SaleService,
    private router: Router,
    private userService: UserService,
    private snackBar: MatSnackBar
  ) {
    this.userEmail = this.userService.getUser();
  }

  ngOnInit(): void {
    var userEmail;
    this.userEmail.subscribe((data: any) => {
      userEmail = data.email;
    });
    if (userEmail) {
      this.saleService.getUserHistory(userEmail).subscribe((sales) => {
        this.sales = sales;
      });
    }
  }

  finalizeSale(saleId: string): void {
    this.saleService.finalizePurchase(saleId).subscribe(() => {
      this.openSnackBar('Compra finalizada com sucesso!');
      setTimeout(() => this.ngOnInit(), 2000);
    });
  }

  cancelSale(saleId: string): void {
    this.saleService.cancelPurchase(saleId).subscribe(() => {
      this.openSnackBar('Compra cancelada!');
      setTimeout(() => this.ngOnInit(), 2000);
    });
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }

  goBack(): void {
    this.router.navigate(['/home']);
  }
}
