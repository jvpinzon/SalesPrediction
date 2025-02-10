import { CommonModule, NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CustomersService, Customers } from '../services/customers.service';
import { OrderService, Order } from '../services/order.service';
import { ProductService } from './../services/product.service';
import { EmployeeService } from './../services/employee.service';
import { ShipperService } from './../services/shipper.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    CommonModule,
    NgFor,
    ReactiveFormsModule
  ],
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})

export class CustomersComponent implements OnInit {
  customers: Customers[] = [];
  orders: Order[] = [];  
  products: any[] = [];
  employees: any[] = [];
  shippers: any[] = [];
  orderForm: FormGroup;
  productForm: FormGroup;
  employeeForm: FormGroup;
  shipperForm: FormGroup;
  searchQuery: any;

  constructor
  (
    private customersService: CustomersService,
    private orderService: OrderService,
    private productService: ProductService,
    private employeeService: EmployeeService,
    private shipperService: ShipperService,
    private modalService: NgbModal,
    private fb: FormBuilder 
  ) { 
    this.orderForm = new FormGroup({
      Employee: new FormControl('', Validators.required),
      Shipper: new FormControl('', Validators.required),
      ShipName: new FormControl('', Validators.required),
      ShipAddress: new FormControl('', Validators.required),
      ShipCity: new FormControl('', Validators.required),
      ShipCountry: new FormControl('', Validators.required),
      orderDate: new FormControl('', Validators.required),
      RequiredDate: new FormControl('', Validators.required),
      ShippedDate: new FormControl('', Validators.required),
      Freight: new FormControl('', Validators.required),
      Product: new FormControl('', Validators.required),
      UnitPrice: new FormControl('', Validators.required),
      Quantity: new FormControl('', Validators.required),
      Discount: new FormControl('', Validators.required),
    });
  
    this.productForm = new FormGroup({
      productId: new FormControl('', Validators.required),
      productname: new FormControl('', Validators.required)
    });
  
    this.employeeForm = new FormGroup({
      empid: new FormControl('', Validators.required),
      FullName: new FormControl('', Validators.required)
    });
  
    this.shipperForm = new FormGroup({
      Shipperid: new FormControl('', Validators.required),
      Companyname: new FormControl('', Validators.required)
    });
  }

  ngOnInit(): void {
    //this.initForm();
    this.loadProducts();
    this.loadEmployees();
    this.loadShippers();

    this.customersService.getCustomers().subscribe(
      (data) => {
        this.customers = data;
      },
      (error) => {
        console.error('Hubo un error al obtener los clientes', error);
      }
    );
  }
  
  /*initForm(): void {
    this.productForm = this.fb.group({
      productId: ['']
    });
    this.employeeForm = this.fb.group({
      employeeId: ['']
    });
    this.shipperForm = this.fb.group({
      shipperId: ['']
    });
    this.orderForm = this.fb.group({
      Employee: ['', Validators.required],
      Shipper: ['', Validators.required],
      ShipName: ['', Validators.required],
      ShipAddress: ['', Validators.required],
      ShipCity: ['', Validators.required],
      ShipCountry: ['', Validators.required],
      orderDate: ['', Validators.required],
      RequiredDate: ['', Validators.required],
      ShippedDate: ['', Validators.required],
      Freight: ['', Validators.required],
      Product: ['', Validators.required],
      UnitPrice: ['', Validators.required],
      Quantity: ['', Validators.required, Validators.min(1)],
      Discount: ['', Validators.required],
    });
  }*/

  openOrderModal(customerId: number, content: any): void {
    this.orderForm.patchValue({ customerId: customerId });
    this.modalService.open(content);
  }

  openOrdersModal(customerId: number, content: any) {
    this.orderService.getOrdersByClient(customerId).subscribe(
      (orders) => {
        this.orders = orders;
        this.modalService.open(content);
      },
      (error) => {
        console.error('Hubo un error al obtener las órdenes', error);
      }
    );
  }
  onSubmit() {
    if (this.orderForm.valid) {
      const orderData = this.orderForm.value;
      this.orderService.createOrder(orderData).subscribe(
        response => {
          console.log('Orden creada:', response);
        },
        error => {
          console.error('Error al crear la orden:', error);
        }
      );
    } else {
      console.log('Formulario no válido');
    }
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe(
      (data) => {
        this.products = data; 
      },
      (error) => {
        console.error('Error al cargar los productos:', error);
      }
    );
  }
  loadEmployees(): void {
    this.employeeService.getEmployees().subscribe(
      (data) => {
        this.employees = data; 
      },
      (error) => {
        console.error('Error al cargar los empleados:', error);
      }
    );
  }
  loadShippers(): void {
    this.shipperService.getShippers().subscribe(
      (data) => {
        this.shippers = data; 
      },
      (error) => {
        console.error('Error al cargar los transportistas:', error);
      }
    );
  }
}
