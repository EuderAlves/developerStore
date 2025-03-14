import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
})
export class UserListComponent implements OnInit {
  users: any;
  constructor(private authService: AuthService, private router: Router) {
    this.users = this.authService.getAllUsers();
  }

  ngOnInit(): void {}

  editUser(userEmail: string): void {
    this.router.navigate(['/edit-user', userEmail]);
  }

  goBack(): void {
    this.router.navigate(['/home']);
  }
}
