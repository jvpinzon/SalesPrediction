import { Component } from '@angular/core';
import { CustomersComponent } from './customers/customers.component';

@Component({
  selector: 'app-root',
  imports: [CustomersComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'sales-date-prediction';
}
