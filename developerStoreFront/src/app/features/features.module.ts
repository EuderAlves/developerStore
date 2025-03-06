import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import { CustomerModule } from './customer/customer.module';
import { AdminModule } from './admin/admin.module';
import { ClientModule } from './client/client.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    AuthModule,
    CustomerModule,
    AdminModule,
    ClientModule,
  ],
  exports: [],
  declarations: [],
})
export class FeaturesModule {}
