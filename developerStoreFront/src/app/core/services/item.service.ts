import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  getItems(): Observable<any> {
    return this.http.get(`${this.apiUrl}/item`);
  }
}
