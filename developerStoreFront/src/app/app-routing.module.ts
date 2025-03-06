import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { HomeComponent } from './features/customer/home/home.component';
import { RegisterUserComponent } from './features/auth/register-user/register-user.component';
import { UserListComponent } from './features/admin/user-list/user-list.component';
import { EditUserComponent } from './features/admin/edit-user/edit-user.component';
import { DeleteUserComponent } from './features/admin/delete-user/delete-user.component';
import { PurchaseHistoryComponent } from './features/admin/purchase-history/purchase-history.component';
import { UserSalesComponent } from './features/admin/user-sales/user-sales.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register-user', component: RegisterUserComponent },
  { path: 'user-list', component: UserListComponent },
  { path: 'edit-user/:id', component: EditUserComponent },
  { path: 'delete-user', component: DeleteUserComponent },
  { path: 'purchase-history', component: PurchaseHistoryComponent },
  { path: 'user-sales/:email', component: UserSalesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
