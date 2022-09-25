import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarModule } from './sidebar/sidebar.module';
import { CustomersModule } from './customers/customers.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SidebarModule,
    CustomersModule
  ],
  exports: [
    SidebarModule,
    CustomersModule
  ]
})
export class ModulesModule { }
