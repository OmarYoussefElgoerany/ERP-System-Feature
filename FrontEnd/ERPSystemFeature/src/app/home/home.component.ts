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
