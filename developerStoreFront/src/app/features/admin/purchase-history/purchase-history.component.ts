import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.scss'],
})
export class PurchaseHistoryComponent implements OnInit {
  users: any;

  constructor(private authService: AuthService, private router: Router) {
    this.users = this.authService.getAllUsers();
  }

  ngOnInit(): void {}

  viewUserHistory(email: string): void {
    this.router.navigate(['/user-sales', email]);
  }
  goBack(): void {
    this.router.navigate(['/home']);
  }
}
