import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.scss'],
})
export class DeleteUserComponent implements OnInit {
  users: any;

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.users = this.authService.getAllUsers();
  }

  ngOnInit(): void {}

  deleteUser(id: string): void {
    debugger;
    this.authService.deleteUser(id).subscribe({
      next: () => {
        this.snackBar.open('Usuário deletado com sucesso!', 'Fechar', {
          duration: 3000,
        });
        this.users = this.authService.getAllUsers();
      },
      error: (err) => {
        console.error('Erro ao deletar usuário:', err);
        this.snackBar.open('Erro ao deletar usuário', 'Fechar', {
          duration: 3000,
        });
      },
    });
  }

  goBack(): void {
    this.router.navigate(['/user-list']);
  }
}
