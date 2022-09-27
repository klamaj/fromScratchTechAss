import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/core/services/customer.service';
import { ICustomer } from 'src/app/shared/Interfaces/icustomer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customer: ICustomer | undefined;

  constructor(private activatedRoute: ActivatedRoute, private customerService: CustomerService) { }

  ngOnInit(): void {
    this.loadCustomer();
  }

  // loadCustomer
  loadCustomer() {
    // console.log(this.activatedRoute.snapshot.paramMap.get("id"));
    this.customerService.getCustomersById(+this.activatedRoute.snapshot.paramMap.get("id")!).subscribe( res => {
      this.customer = res;
    })
  }

}
