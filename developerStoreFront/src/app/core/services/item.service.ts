import { HttpClient } from '@angular/common/http';
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
    return this.http.get(`${this.apiUrl}/item`);
  }
}
