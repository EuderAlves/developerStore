import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from 'src/app/auth-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material.module';
import { CartComponent } from './cart/cart.component';
import { PurchaseItemsComponent } from './purchase-items/purchase-items.component';

@NgModule({
  declarations: [CartComponent, PurchaseItemsComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
  ],
  exports: [PurchaseItemsComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class ClientModule {}
