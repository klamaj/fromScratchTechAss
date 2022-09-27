import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/core/services/customer.service';
import { ICustomer } from 'src/app/shared/Interfaces/icustomer';

@Component({
  selector: 'app-newcustomer',
  templateUrl: './newcustomer.component.html',
  styleUrls: ['./newcustomer.component.scss']
})
export class NewcustomerComponent implements OnInit {

  customer: FormGroup;
  address: FormGroup;

  constructor(private customerService: CustomerService) {
    this.customer = this.createCustomer();
    this.address = this.createAddress();
  }

  ngOnInit(): void {
  }

  // createCustomer
  createCustomer() {
    return new FormGroup({
      firstName: new FormControl(undefined, [Validators.required]),
      lastName: new FormControl(undefined, [Validators.required]),
      email: new FormControl(undefined, [Validators.required, Validators.email]),
      phone: new FormControl(undefined, [Validators.required])
    });
  }

  // createAddress
  createAddress() {
    return new FormGroup({

    });
  }

  // addCustomer
  addCustomer(form: FormGroup) {
    // console.log(form)
    if (form.valid) {

      let customer = {
        firstName: form.value.firstName,
        lastName: form.value.lastName,
        email: form.value.email,
        phoneNumber: form.value.phone
      } as ICustomer

      this.customerService.addCustomer(customer).subscribe(res => {
        console.log(res);
      })
    }
  }

}
