import { Component } from '@angular/core';
import { Location } from '@angular/common';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  PatternValidator,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { IAddCustomerDto } from '../../Dtos/CustomerDtos/IAddCustomerDto';
@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrl: './add-customer.component.css',
})
export class AddCustomerComponent {
  addCustomer;
  tryAgainError?: boolean = false;

  constructor(
    private fB: FormBuilder,
    private customerService: CustomerService,
    private router: Router,
    private location: Location
  ) {
    this.addCustomer = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(3),
      ]),
      job: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(3),
      ]),
      nationality: new FormControl<string>('', [
        Validators.maxLength(10),
        Validators.minLength(3),
      ]),
      residance: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(3),
      ]),
      mobile: new FormControl<number>(0, [
        Validators.minLength(5),
        Validators.required,
      ]),
      address: new FormControl<string>('', [
        Validators.maxLength(20),
        Validators.minLength(3),
      ]),
      whatsapp: new FormControl<number>(0, [
        Validators.maxLength(11),
        Validators.minLength(5),
      ]),
      dateAdded: new FormControl<string>('1/1/2024'),
      lastEdit: new FormControl<string>('1/1/2024'),
      customerRating: new FormControl<string>(''),
      employeeId: new FormControl<number>(0),
    });
  }

  ngOnInit(): void {}
  // property readOnly
  get Name() {
    return this.addCustomer.get('name');
  }
  get Job() {
    return this.addCustomer.get('job');
  }
  get Address() {
    return this.addCustomer.get('address');
  }
  get Mobile() {
    return this.addCustomer.get('mobile');
  }
  get Residance() {
    return this.addCustomer.get('residance');
  }
  get Whatsapp() {
    return this.addCustomer.get('whatsapp');
  }
  get Nationality() {
    return this.addCustomer.get('nationality');
  }
  get DateAdded() {
    return this.addCustomer.get('dateAdded');
  }
  get LastEdit() {
    return this.addCustomer.get('lastEdit');
  }
  get CustomerRating() {
    return this.addCustomer.get('customerRating');
  }
  get EmployeeId() {
    return this.addCustomer.get('employeeId');
  }
  handleSubmit(e: Event) {
    e.preventDefault();
    if (this.addCustomer.invalid) return;
    const custmr: IAddCustomerDto = {
      name: this.addCustomer.value.name!,
      job: this.addCustomer.value.job!,
      address: this.addCustomer.value.address!,
      mobile: this.addCustomer.value.mobile!,
      whatsapp: this.addCustomer.value.whatsapp!,
      nationality: this.addCustomer.value.nationality!,
      dateAdded: this.addCustomer.value.dateAdded!,
      lastEdit: this.addCustomer.value.lastEdit!,
      customerRating: this.addCustomer.value.customerRating!,
      employeeId: this.addCustomer.value.employeeId!,
      residance: this.addCustomer.value.residance!,
    };
    this.customerService.Add(custmr).subscribe({
      next: (data) => {
        console.log(data);
      },
      error: () => {
        console.log(`error`);
        this.tryAgainError = true;
      },
    });
  }
  goBack(): void {
    this.location.back();
  }
}
