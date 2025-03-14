import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';
import { ItemService } from 'src/app/core/services/item.service';
import { SaleService } from 'src/app/core/services/sale.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  user$: Observable<any | null>;
  user: any | null = null;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router
  ) {
    this.user$ = this.userService.getUser();
  }

  ngOnInit(): void {
    this.user$.subscribe((data) => {
      this.user = data;
      console.log('Dados do usuário no store:', this.user);
    });
  }

  navigateTo(route: string): void {
    this.router.navigate([route]);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
