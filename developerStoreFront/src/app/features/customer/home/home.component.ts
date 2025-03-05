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
  user: any | null = null; // Armazena os dados do usuário

  constructor(
    private fb: FormBuilder,
    private apiSaleService: SaleService,
    private apiAuthService: AuthService,
    private apiItemService: ItemService,
    private userService: UserService,
    private router: Router
  ) {
    this.user$ = this.userService.getUser();
  }

  ngOnInit(): void {
    this.user$.subscribe((data) => {
      this.user = data; // Salva os dados do usuário na variável `user`
      console.log('Dados do usuário no store:', this.user); // Confirma se os dados foram recuperados
    });
  }

  navigateTo(route: string): void {
    this.router.navigate([route]);
  }
}
