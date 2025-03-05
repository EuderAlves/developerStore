import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { SaleService } from 'src/app/core/services/sale.service';
import { ItemService } from 'src/app/core/services/item.service';
import { UserService } from 'src/app/core/services/user.service';

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
    private userService: UserService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      passwordHash: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { email, passwordHash } = this.loginForm.value;
      this.isLoading = true;

      this.apiAuthService.login(email, passwordHash).subscribe({
        next: (response) => {
          this.isLoading = false;
          if (response.status === 200) {
            this.apiAuthService.getUser(email).subscribe({
              next: (user: any) => {
                console.log('Usuário recebido:', user);
                this.userService.setUser(user); // Salva o usuário

                // Buscar histórico do usuário
                this.apiSaleService.getUserHistory(email).subscribe({
                  next: (history) => {
                    this.userService.setUserHistory(history); // Salva o histórico
                  },
                  error: (err) => {
                    console.error('Erro ao buscar histórico:', err);
                  },
                });

                // Buscar itens à venda
                this.apiItemService.getItems().subscribe({
                  next: (items) => {
                    this.userService.setItems(items); // Salva os itens
                  },
                  error: (err) => {
                    console.error('Erro ao buscar itens:', err);
                  },
                });

                this.router.navigate(['/home']);
              },
              error: (err) => {
                console.error('Erro ao buscar usuário:', err);
              },
            });
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
