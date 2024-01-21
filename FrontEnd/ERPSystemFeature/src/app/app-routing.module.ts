import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './Customer/add-customer/add-customer.component';

import { EditCustomerComponent } from './Customer/edit-customer/edit-customer.component';

const routes: Routes = [
  { path: 'add', component: AddCustomerComponent },
  { path: 'edit/:id', component: EditCustomerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
