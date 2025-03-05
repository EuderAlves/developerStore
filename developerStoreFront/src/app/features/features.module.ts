import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import { MaterialModule } from '../material/material.module';

@NgModule({
  imports: [CommonModule, AuthModule],
  exports: [AuthModule],
})
export class FeaturesModule {}
