import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { IReadCustomerDto } from '../Dtos/CustomerDtos/IReadCustomerDto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  displayedColumns: string[] = [
    'id',
    'name',
    'job',
    'address',
    'residance',
    'mobile',
    'whatsapp',
    'nationality',
    'dateAdded',
    'lastEdit',
    'customerRating',
  ];
  inputData = new Set<string>();
  selectedColumns: string[] = [];
  onCheckboxChange(coloumn: string) {
    if (!this.selectedColumns.includes(coloumn)) {
      this.selectedColumns.push(coloumn);
    }
    console.log(coloumn);
  }
}
// handleButtonClick(input: string) {}
// totalCount = 0;
// page = 1;
// customers: IReadCustomerDto[] = [];
// countPerPage = 10;
// isLoaded: boolean = false;
// constructor(
//   private customerService: CustomerService,
//   private renderer: Renderer2,
//   private el: ElementRef
// ) {}
// ngOnInit(): void {
//   this.getCustomers(1);
// }

// public getCustomers(page: number) {
//   this.customerService
//     .GetAllWithPagi(page, this.countPerPage)
//     .subscribe((customersPagi) => {
//       this.isLoaded = true;
//       this.totalCount = customersPagi.totalCount;
//       this.customers = customersPagi.customerDtos;
//       this.page = page;
//     });
// }
