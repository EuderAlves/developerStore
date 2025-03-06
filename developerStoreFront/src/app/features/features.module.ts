import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import { CustomerModule } from './customer/customer.module';
import { UserListComponent } from './admin/user-list/user-list.component';
import { AdminModule } from './admin/admin.module';

@NgModule({
  imports: [CommonModule, AuthModule, CustomerModule, AdminModule],
  exports: [AuthModule],
})
export class FeaturesModule {}
