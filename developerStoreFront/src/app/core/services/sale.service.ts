import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getApiUrl } from 'src/app/core/services/utils/http-utils';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  private apiUrl = getApiUrl();

  constructor(private http: HttpClient) {}

  getUserHistory(email: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.apiUrl}/sale/customer/${encodeURIComponent(email)}`
    );
  }
}
