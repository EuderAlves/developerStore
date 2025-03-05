import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  private apiUrl = 'https://developerstore.onrender.com/api';
  private apiUrlLocalhost = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}
  getItems(): Observable<any> {
    return this.http.get(`${this.apiUrlLocalhost}/item`);
  }
}
