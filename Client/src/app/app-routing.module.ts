import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './modules/customers/customers.component';
import { NewcustomerComponent } from './modules/customers/newcustomer/newcustomer.component';

const routes: Routes = [
  { path: "customers", component: CustomersComponent },
  { path: "customer/:id", component: NewcustomerComponent },
  { path: "customer/new", component: NewcustomerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
