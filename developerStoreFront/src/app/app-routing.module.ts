import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { HomeComponent } from './features/customer/home/home.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  // { path: 'register-user', component: RegisterUserComponent }, // Exemplo
  // { path: 'edit-user', component: EditUserComponent }, // Exemplo
  // { path: 'delete-user', component: DeleteUserComponent }, // Exemplo
  // { path: 'view-users', component: ViewUsersComponent }, // Exemplo
  // { path: 'user-history', component: UserHistoryComponent }, // Exemplo
  // { path: 'purchase-items', component: PurchaseItemsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
