import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { getApiUrl } from 'src/app/core/services/utils/http-utils';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = getApiUrl();

  constructor(private http: HttpClient) {}

  // Método para fazer login
  login(email: string, passwordHash: string): Observable<HttpResponse<any>> {
    return this.http.post(
      `${this.apiUrl}/user/login`,
      {
        email,
        passwordHash,
      },
      { observe: 'response' }
    );
  }

  getUser(email: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/user/email/${email}`);
  }
}
