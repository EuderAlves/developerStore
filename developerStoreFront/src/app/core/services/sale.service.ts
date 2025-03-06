import { HttpClient, HttpResponse } from '@angular/common/http';
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

  savePurchase(savePurchase: any): Observable<HttpResponse<any>> {
    return this.http.post<any>(`${this.apiUrl}/sale/register`, savePurchase, {
      observe: 'response',
    });
  }

  cancelPurchase(id: string): Observable<HttpResponse<any>> {
    return this.http.post(
      `${this.apiUrl}/sale/${id}/cancel`,
      {},
      {
        observe: 'response',
      }
    );
  }
  finalizePurchase(id: string): Observable<HttpResponse<any>> {
    return this.http.post(
      `${this.apiUrl}/sale/${id}/finalize`,
      {},
      {
        observe: 'response',
      }
    );
  }
}
