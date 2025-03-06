import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getApiUrl } from 'src/app/core/services/utils/http-utils';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private apiUrl = getApiUrl();

  constructor(private http: HttpClient) {}
  getItems(): Observable<any> {
    return this.http.get(`${this.apiUrl}/item/all`);
  }
  getItemById(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/item/${id}`);
  }

  getAllItems(): Observable<any> {
    return this.http.get(`${this.apiUrl}/item/all`);
  }
  addItem(itemData: any): Observable<HttpResponse<any>> {
    return this.http.post(`${this.apiUrl}/item/add`, itemData, {
      observe: 'response',
    });
  }
  updateItem(id: string, itemUpdate: any): Observable<HttpResponse<any>> {
    return this.http.put(`${this.apiUrl}/item/${id}`, itemUpdate, {
      observe: 'response',
    });
  }

  deleteItem(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/item/${id}`);
  }
}
