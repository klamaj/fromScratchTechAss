import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/core/services/customer.service';
import { IAddress } from 'src/app/shared/Interfaces/iaddress';
import { ICustomer } from 'src/app/shared/Interfaces/icustomer';

@Component({
  selector: 'app-newcustomer',
  templateUrl: './newcustomer.component.html',
  styleUrls: ['./newcustomer.component.scss']
})
export class NewcustomerComponent implements OnInit {

  customer: FormGroup;
  addressForm: FormGroup;
  add: boolean = false;
  addresses: IAddress[] = [];

  constructor(private customerService: CustomerService) {
    this.customer = this.createCustomer();
    this.addressForm = this.createAddress();
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
      street: new FormControl(undefined, [Validators.required]),
      streetNumber: new FormControl(undefined, [Validators.required]),
      city: new FormControl(undefined, [Validators.required]),
      country: new FormControl(undefined, [Validators.required]),
      zipCode: new FormControl(undefined, [Validators.required])
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
        phoneNumber: form.value.phone,
        addresses: this.addresses
      } as ICustomer

      this.customerService.addCustomer(customer).subscribe(res => {
        // console.log(res);
      })
    }
  }

  // addAddress
  addAddress(form: FormGroup) {
    if (form.valid) {
      let address = {
        street: form.value.street,
        streetNumber: form.value.streetNumber,
        city: form.value.city,
        country: form.value.country,
        zipCode: form.value.zipCode,
      } as IAddress

      this.addresses.push(address);
      this.addressForm.reset();
      this.add = false;
    }
  }

  removeAddress(val: number) {
    this.addresses.splice(val);
    // console.log(val);
  }

}
