import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './modules/customers/customer/customer.component';
import { CustomersComponent } from './modules/customers/customers.component';
import { NewcustomerComponent } from './modules/customers/newcustomer/newcustomer.component';

const routes: Routes = [
  { path: "customers", component: CustomersComponent },
  { path: "customer/new", component: NewcustomerComponent },
  { path: "customer/:id", component: CustomerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
