import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './customers.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { NewcustomerModule } from './newcustomer/newcustomer.module';



@NgModule({
  declarations: [
    CustomersComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    NewcustomerModule
  ],
  exports: [
    CustomersComponent,
    NewcustomerModule
  ]
})
export class CustomersModule { }
