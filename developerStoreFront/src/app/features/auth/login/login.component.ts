import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AuthService } from 'src/app/core/services/auth.service';
import { SaleService } from 'src/app/core/services/sale.service';
import { ItemService } from 'src/app/core/services/item.service';
import { setUser } from 'src/app/store/actions/user.actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';
  isLoading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private apiSaleService: SaleService,
    private apiAuthService: AuthService,
    private apiItemService: ItemService,
    private router: Router,
    private store: Store
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      passwordHash: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    debugger;
    if (this.loginForm.valid) {
      const { email, passwordHash } = this.loginForm.value;
      this.isLoading = true;

      this.apiAuthService.login(email, passwordHash).subscribe({
        next: (response) => {
          if (response.status === 200) {
            this.isLoading = false;
            this.apiSaleService.getUserHistory(email).subscribe({
              next: (history) => {
                console.log('Histórico do usuário:', history);
              },
              error: (err) => {
                console.error('Erro ao buscar histórico:', err);
              },
            });

            this.apiItemService.getItems().subscribe({
              next: (items) => {
                console.log('Itens à venda:', items);
              },
              error: (err) => {
                console.error('Erro ao buscar itens:', err);
              },
            });

            this.router.navigate(['/home']);
          } else {
            this.errorMessage = 'Erro ao logar';
          }
        },
        error: (err) => {
          this.isLoading = false;
          this.errorMessage = 'Erro ao logar';
          console.error(err);
        },
      });
    }
  }
}
