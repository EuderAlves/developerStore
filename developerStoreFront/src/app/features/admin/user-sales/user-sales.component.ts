import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SaleService } from 'src/app/core/services/sale.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-sales',
  templateUrl: './user-sales.component.html',
  styleUrls: ['./user-sales.component.scss'],
})
export class UserSalesComponent implements OnInit {
  sales$: Observable<any[]> | undefined;
  userEmail: string | null;

  constructor(
    private route: ActivatedRoute,
    private saleService: SaleService,
    private router: Router
  ) {
    this.userEmail = this.route.snapshot.paramMap.get('email');
  }

  ngOnInit(): void {
    if (this.userEmail) {
      this.sales$ = this.saleService.getUserHistory(this.userEmail);
    }
  }

  goBack(): void {
    this.router.navigate(['/purchase-history']);
  }

  getTotalValue(sales: any[]): number {
    return sales.reduce((total, sale) => total + sale.totalValue, 0);
  }

  getTotalItems(sales: any[]): number {
    return sales.reduce((total, sale) => {
      return (
        total +
        sale.items.reduce(
          (itemTotal: number, item: any) => itemTotal + item.quantity,
          0
        )
      );
    }, 0);
  }

  getTotalFinalized(sales: any[]): number {
    return sales.filter((sale) => sale.isFinalized).length;
  }

  getTotalCanceled(sales: any[]): number {
    return sales.filter((sale) => sale.isCanceled).length;
  }
}
