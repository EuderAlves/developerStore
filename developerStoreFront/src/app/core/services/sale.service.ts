import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUserHistory(email: string): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/sale/customer/${encodeURIComponent(email)}`
    );
  }
}
