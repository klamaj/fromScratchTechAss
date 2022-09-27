import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerComponent } from './customer.component';
import { AppRoutingModule } from 'src/app/app-routing.module';



@NgModule({
  declarations: [
    CustomerComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports: [
    CustomerComponent
  ]
})
export class CustomerModule { }
