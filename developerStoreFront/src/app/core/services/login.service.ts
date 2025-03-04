import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private apiUrl = 'https://developerstore.onrender.com/api'; // URL do seu backend

  constructor(private http: HttpClient) {}

  // Método para fazer login
  login(email: any, password: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/User/login`, { email, password });
  }

  // Método para buscar histórico do usuário
  getUserHistory(email: string): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/Sale/customer/${encodeURIComponent(email)}`
    );
  }

  // Método para buscar itens para venda
  getItems(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Item`);
  }
}
