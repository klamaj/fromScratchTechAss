import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './customers.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { NewcustomerModule } from './newcustomer/newcustomer.module';
import { CustomerModule } from './customer/customer.module';



@NgModule({
  declarations: [
    CustomersComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    NewcustomerModule,
    CustomerModule
  ],
  exports: [
    CustomersComponent,
    NewcustomerModule,
    CustomerModule
  ]
})
export class CustomersModule { }
