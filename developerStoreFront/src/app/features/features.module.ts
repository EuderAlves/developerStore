import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import { CustomerModule } from './customer/customer.module';

@NgModule({
  imports: [CommonModule, AuthModule, CustomerModule],
  exports: [AuthModule],
})
export class FeaturesModule {}
