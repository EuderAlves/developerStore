import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component'; // Ajuste o caminho conforme necessário

const routes: Routes = [
  { path: '', component: LoginComponent }, // Defina suas rotas aqui
  // Outras rotas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // Configuração das rotas
  exports: [RouterModule],
})
export class AppRoutingModule {}
