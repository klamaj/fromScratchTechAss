import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICustomer } from 'src/app/shared/Interfaces/icustomer';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  private ApiUrl: string = "https://localhost:7244/api/v1.0/Customer/";

  constructor(private http: HttpClient) { }

  // GetCustomers
  GetCustomers() {
    return this.http.get(this.ApiUrl+"get");
  }

  // GetCustomerById
  GetCustomerById(id: number) {
    return this.http.get("");
  }
}
