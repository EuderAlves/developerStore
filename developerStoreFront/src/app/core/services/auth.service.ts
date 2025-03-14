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

  getAllUsers(): Observable<any> {
    return this.http.get(`${this.apiUrl}/user/all`);
  }
  getUser(email: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/user/email/${email}`);
  }

  registerUser(userData: any): Observable<HttpResponse<any>> {
    return this.http.post(`${this.apiUrl}/user/register`, userData, {
      observe: 'response',
    });
  }

  updateUser(email: string, userData: any): Observable<HttpResponse<any>> {
    return this.http.put(`${this.apiUrl}/user/update/${email}`, userData, {
      observe: 'response',
    });
  }

  deleteUser(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/user/${id}`);
  }

  logout(): void {
    localStorage.removeItem('user');
  }
}
