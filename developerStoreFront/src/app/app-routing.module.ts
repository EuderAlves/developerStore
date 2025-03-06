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
import { ManageItemsComponent } from './features/admin/manage-items/manage-items.component';
import { AddItemComponent } from './features/admin/add-item/add-item.component';
import { EditItemComponent } from './features/admin/edit-item/edit-item.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register-user', component: RegisterUserComponent },
  { path: 'user-list', component: UserListComponent },
  { path: 'edit-user/:id', component: EditUserComponent },
  { path: 'delete-user', component: DeleteUserComponent },
  { path: 'purchase-history', component: PurchaseHistoryComponent },
  { path: 'user-sales/:email', component: UserSalesComponent },
  { path: 'manage-items', component: ManageItemsComponent },
  { path: 'add-item', component: AddItemComponent },
  { path: 'edit-item/:id', component: EditItemComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
