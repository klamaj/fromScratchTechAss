import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/core/services/customer.service';
import { ICustomer } from 'src/app/shared/Interfaces/icustomer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {

  customers: ICustomer[] = [];

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers() {
    this.customerService.getCustomers().subscribe(res => {
      // console.log(res);
      this.customers = res;
    })
  }

  // removeCustomer
  removeCustomer(id: number) {
    this.customerService.deleteCustomer(id).subscribe(res => {
      this.loadCustomers();
    })
  }
}
