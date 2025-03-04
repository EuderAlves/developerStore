import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router'; // Importa RouterModule
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';

@NgModule({
  declarations: [
    AppComponent,
    // Outros componentes
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
