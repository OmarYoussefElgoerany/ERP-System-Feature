import { Component } from '@angular/core';
import { Location } from '@angular/common';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  PatternValidator,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { IReadCustomerDto } from '../../Dtos/CustomerDtos/IReadCustomerDto';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css',
})
export class EditCustomerComponent {
  editCustomer: any;
  customerId!: number;
  customer!: IReadCustomerDto;
  tryAgainError?: boolean = false;
  constructor(
    private customerService: CustomerService,
    private router: Router,
    private location: Location,
    private activatedRoute: ActivatedRoute
  ) {
    this.editCustomer = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(3),
      ]),
      id: new FormControl<number>(0),
      job: new FormControl<string>('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(3),
      ]),
      nationality: new FormControl<string>('', [
        Validators.maxLength(15),
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
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((map) => {
      this.customerId = +map.get('id')!;
    });

    this.customerService.GetById(this.customerId).subscribe((data) => {
      this.customer = {
        id: data.id,
        name: data.name,
        job: data.job,
        address: data.address,
        residance: data.residance,
        mobile: data.mobile,
        whatsapp: data.whatsapp,
        nationality: data.nationality,
        dateAdded: data.dateAdded,
        lastEdit: data.lastEdit,
        customerRating: data.lastEdit,
        employeeId: data.employeeId,
      };
      this.editCustomer.setValue(this.customer);
    });
  }
  get Name() {
    return this.editCustomer.get('name');
  }
  get Job() {
    return this.editCustomer.get('job');
  }
  get Address() {
    return this.editCustomer.get('address');
  }
  get Mobile() {
    return this.editCustomer.get('mobile');
  }
  get Residance() {
    return this.editCustomer.get('residance');
  }
  get Whatsapp() {
    return this.editCustomer.get('whatsapp');
  }
  get Nationality() {
    return this.editCustomer.get('nationality');
  }
  get DateAdded() {
    return this.editCustomer.get('dateAdded');
  }
  get LastEdit() {
    return this.editCustomer.get('lastEdit');
  }
  get CustomerRating() {
    return this.editCustomer.get('customerRating');
  }
  get EmployeeId() {
    return this.editCustomer.get('employeeId');
  }
  handleSubmit(e: Event) {
    e.preventDefault();
    if (this.editCustomer.invalid) return;
    let editCustomer: IReadCustomerDto = {
      id: this.editCustomer.value.id,
      name: this.editCustomer.value.name,
      job: this.editCustomer.value.job,
      address: this.editCustomer.value.address,
      residance: this.editCustomer.value.residance,
      mobile: this.editCustomer.value.mobile,
      whatsapp: this.editCustomer.value.whatsapp,
      nationality: this.editCustomer.value.nationality,
      dateAdded: this.editCustomer.value.dateAdded,
      lastEdit: this.editCustomer.value.lastEdit,
      customerRating: this.editCustomer.value.customerRating,
      employeeId: this.editCustomer.value.id,
    };

    this.customerService.Edit(editCustomer).subscribe({
      next: (data) => {
        console.log(`the data is ${data}`);
      },
      error: (error) => {
        console.log(`error`);
      },
    });
  }
  goBack(): void {
    this.location.back();
  }
}
