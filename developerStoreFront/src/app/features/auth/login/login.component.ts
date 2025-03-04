import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { setUser } from '../../../store/actions/user.actions'; // Ação para armazenar o usuário no Store
import { LoginService } from '../../../core/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private apiService: LoginService,
    private router: Router,
    private store: Store
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;

      this.apiService.login(email, password).subscribe({
        next: (response) => {
          if (response.status === 200) {
            // Salvar usuário no store
            this.store.dispatch(setUser({ user: response.data }));

            // Buscar histórico do usuário
            // this.apiService.getUserHistory(email).subscribe({
            //   next: (history) => {
            //     // Armazenar histórico no store ou em algum serviço
            //     console.log('Histórico do usuário:', history);
            //   },
            //   error: (err) => {
            //     console.error('Erro ao buscar histórico:', err);
            //   },
            // });

            // Redirecionar para a página inicial ou dashboard
            this.router.navigate(['/home']);
          } else {
            this.errorMessage = 'Erro ao logar';
          }
        },
        error: (err) => {
          this.errorMessage = 'Erro ao logar';
          console.error(err);
        },
      });
    }
  }
}
