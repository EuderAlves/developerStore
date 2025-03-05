import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://developerstore.onrender.com/api';
  private apiUrlLocalhost = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}

  // Método para fazer login
  login(email: string, passwordHash: string): Observable<HttpResponse<any>> {
    return this.http.post(
      `${this.apiUrlLocalhost}/user/login`,
      {
        email,
        passwordHash,
      },
      { observe: 'response' }
    );
  }
}
