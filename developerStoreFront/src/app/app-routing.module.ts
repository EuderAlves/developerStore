import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { HomeComponent } from './features/customer/home/home.component';
import { RegisterUserComponent } from './features/auth/register-user/register-user.component';
import { UserListComponent } from './features/admin/user-list/user-list.component';
import { EditUserComponent } from './features/admin/edit-user/edit-user.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register-user', component: RegisterUserComponent },
  { path: 'user-list', component: UserListComponent },
  { path: 'edit-user/:id', component: EditUserComponent },
  // { path: 'view-users', component: ViewUsersComponent }, // Exemplo
  // { path: 'user-history', component: UserHistoryComponent }, // Exemplo
  // { path: 'purchase-items', component: PurchaseItemsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
