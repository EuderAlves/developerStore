import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss'],
})
export class EditUserComponent implements OnInit {
  editUserForm: FormGroup;
  userEmail: any;
  user: any;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.editUserForm = this.fb.group({
      name: ['', [Validators.required]],
      companyName: ['', [Validators.required]],
      userType: [null, [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.userEmail = this.route.snapshot.paramMap.get('id');

    this.authService.getUser(this.userEmail).subscribe((data) => {
      this.user = data;
      this.editUserForm.patchValue(this.user);
    });
  }

  onSubmit(): void {
    if (this.editUserForm.valid) {
      const updatedUser = { ...this.editUserForm.value };
      this.authService.updateUser(this.userEmail, updatedUser).subscribe(() => {
        this.openSnackBar('Usuário cadastrado com sucesso!');
        setTimeout(() => this.router.navigate(['/user-list']), 2000);
        this.router.navigate(['/user-list']);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/user-list']);
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }
}
