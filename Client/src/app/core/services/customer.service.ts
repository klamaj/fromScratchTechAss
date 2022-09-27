import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICustomer } from 'src/app/shared/Interfaces/icustomer';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  private ApiUrl: string = "https://localhost:7244/api/v1.0/Customer/";

  constructor(private http: HttpClient) { }

  // getCustomers
  getCustomers() {
    return this.http.get<ICustomer[]>(this.ApiUrl + "get").pipe(
      map((res: ICustomer[]) => {
        let customers: ICustomer[] = [];
        if (res) {
          res.forEach(elm => {
            let cust = {
              id:  elm.id,
              firstName: elm.firstName,
              lastName: elm.lastName,
              email: elm.email,
              phoneNumber: elm.phoneNumber
            } as ICustomer
            customers.push(cust)
          })
        }
        return customers;
      })
    )
  }

  // getCustomersById
  getCustomersById(id: number) {
    return this.http.get<ICustomer>(this.ApiUrl + "get/" + id);
  }

  // addCustomer
  addCustomer(val: ICustomer) {
    return this.http.post<ICustomer>(this.ApiUrl + "add", val);
  }
}
