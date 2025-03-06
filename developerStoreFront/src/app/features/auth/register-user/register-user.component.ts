import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserService } from 'src/app/core/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss'],
})
export class RegisterUserComponent implements OnInit {
  registerForm: FormGroup;
  errorMessage: string = '';
  hidePassword: boolean = true;
  hideConfirmPassword: boolean = true;
  userLogged: boolean = false;

  constructor(
    private fb: FormBuilder,
    private apiAuthService: AuthService,
    private userService: UserService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.registerForm = this.fb.group(
      {
        name: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        passwordHash: ['', [Validators.required]],
        confirmPassword: ['', [Validators.required]],
        companyName: ['', [Validators.required]],
        userType: [null, [Validators.required]],
      },
      { validators: this.passwordMatchValidator }
    );
  }

  ngOnInit(): void {
    this.userService.getUser().subscribe((user) => {
      if (user) {
        this.userLogged = true;
      } else {
        this.userLogged = false;
      }
    });
  }

  passwordMatchValidator(form: FormGroup) {
    return form.get('passwordHash')?.value ===
      form.get('confirmPassword')?.value
      ? null
      : { passwordMismatch: true };
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      const { name, email, passwordHash, companyName, userType } =
        this.registerForm.value;

      this.apiAuthService
        .registerUser({ name, email, passwordHash, companyName, userType })
        .subscribe({
          next: (response) => {
            if (response.status === 201) {
              this.openSnackBar('Usuário cadastrado com sucesso!');
              setTimeout(
                () =>
                  this.router.navigate([
                    this.userLogged === true ? '/home' : '/login',
                  ]),
                2000
              );
            } else {
              this.errorMessage = 'Erro ao cadastrar usuário';
            }
          },
          error: (err) => {
            this.errorMessage = 'Erro ao cadastrar usuário';
            console.error(err);
          },
        });
    }
  }

  cancel(): void {
    this.router.navigate([this.userLogged === true ? '/home' : '/login']);
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }
}
