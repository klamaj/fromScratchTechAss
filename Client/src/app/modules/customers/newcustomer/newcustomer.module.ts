import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewcustomerComponent } from './newcustomer.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    NewcustomerComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  exports: [
    NewcustomerComponent
  ]
})
export class NewcustomerModule { }
