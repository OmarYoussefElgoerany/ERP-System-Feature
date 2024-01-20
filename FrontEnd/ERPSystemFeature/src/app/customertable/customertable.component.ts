import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { MatTableDataSource } from '@angular/material/table';
import { IReadCustomerDto } from '../Dtos/CustomerDtos/IReadCustomerDto';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-customertable',
  templateUrl: './customertable.component.html',
  styleUrl: './customertable.component.css',
})
export class CustomertableComponent implements OnInit {
  @ViewChild(MatPaginator) paginator?: MatPaginator;
  dataSource: any;
  length = 500;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  isLoaded: boolean = false;
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
  forCheckedCol = this.displayedColumns;
  selectedColumns: string[] = [];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.customerService.GetAll().subscribe((data) => {
      this.dataSource = new MatTableDataSource<IReadCustomerDto>(data);
      this.isLoaded = true;
      this.dataSource.paginator = this.paginator;
    });
  }
  private handleInputDataChange() {
    this.displayedColumns = this.selectedColumns;
  }

  onCheckboxChange(column: string, event: Event) {
    const isChecked = (event.target as HTMLInputElement).checked;

    if (isChecked) {
      this.selectedColumns.push(column);
    } else {
      const index = this.selectedColumns.indexOf(column);
      if (index !== -1) {
        this.selectedColumns.splice(index, 1);
      }
    }
    this.handleInputDataChange();
  }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
  }

  filterInput(input: HTMLInputElement) {
    let inputValue = input.value.trim().toLocaleLowerCase();
    this.findCustomer(inputValue);
  }
  findCustomer(inputValue: string) {
    this.dataSource.filter = inputValue;
  }
}
