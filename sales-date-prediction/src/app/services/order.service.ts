import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Order {
  Orderid: number;
  Requireddate: string;
  Shippeddate: string;
  Shipname: string;
  Shipaddress: string;
  Shipcity: string;
}
@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl = 'http://localhost:5026/api/Orders';

  constructor(private http: HttpClient) { }

  getOrdersByClient(customerId: number): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}/${customerId}`);
  }
  createOrder(orderData: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, orderData);
  }
}