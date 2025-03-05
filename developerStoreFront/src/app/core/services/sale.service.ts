import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  private apiUrl = 'https://developerstore.onrender.com/api';
  private apiUrlLocalhost = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}

  getUserHistory(email: string): Observable<any> {
    return this.http.get(
      `${this.apiUrlLocalhost}/sale/customer/${encodeURIComponent(email)}`
    );
  }
}
