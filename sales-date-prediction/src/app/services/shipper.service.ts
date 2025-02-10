import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {

  private apiUrl = 'http://localhost:5026/api/Shippers'; 

  constructor(private http: HttpClient) { }

  getShippers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}