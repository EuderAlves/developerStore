import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from 'src/app/auth-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { UserListComponent } from './user-list/user-list.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { PurchaseHistoryComponent } from './purchase-history/purchase-history.component';
import { UserSalesComponent } from './user-sales/user-sales.component';
import { ManageItemsComponent } from './manage-items/manage-items.component';
import { AddItemComponent } from './add-item/add-item.component';
import { EditItemComponent } from './edit-item/edit-item.component';

@NgModule({
  declarations: [UserListComponent, EditUserComponent, DeleteUserComponent, PurchaseHistoryComponent, UserSalesComponent, ManageItemsComponent, AddItemComponent, EditItemComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  exports: [UserListComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AdminModule {}
