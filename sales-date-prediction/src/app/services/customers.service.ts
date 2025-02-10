import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Customers {
  customersId: number;
  Customer_Name: string;
  Last_Order_Date: string;
  Next_Predicted_Order: string;
}

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  private apiUrl = 'http://localhost:5026/api/SalesPrediction';

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customers[]> {
    return this.http.get<Customers[]>(this.apiUrl);
  }
}